using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GenderedTerms {

    public class GenderedTermLoader : MonoBehaviour {
        private FungusHelper fungusHelper;

		public void Start() {
            fungusHelper = FungusHelper.Instance;

            // need to wait until Fungus populates the Global Variables after a scene load - this is done after Start()
            // otherwise, our values could be overwritten by Fungus
            StartCoroutine(UpdateAllGenderedTermVariablesAsync());
		}

        private IEnumerator UpdateAllGenderedTermVariablesAsync() {
            // should do a more robust check of when the Global Variables have been populated, but this is sufficient
            yield return new WaitForSeconds(0.1f);

            UpdateAllGenderedTermVariables();
        }

        public void UpdateAllGenderedTermVariables() {
            List<DynamicGenderCharacter> characters = DynamicGenderCharacterGameData.GetCharacters();

            foreach (DynamicGenderCharacter character in characters) {
                UpdateGenderedTermVariablesForCharacter(character);
            }
        }

        private void UpdateGenderedTermVariablesForCharacter(DynamicGenderCharacter character) {
            Pronoun? pronounOrNull = ReadPronounFromFungusVar(character.PronounVarName);
            if (!pronounOrNull.HasValue) {
                Debug.LogWarning("Unable to load Fungus variables for character: " + character.Name);
                return;
            }

            Pronoun pronoun = pronounOrNull.Value;
            Dictionary<GenderedTermType, string> genderedTermsByTermType = GenderedTermDictionary.GetGenderedTermsForPronoun(pronoun);

            foreach (KeyValuePair<GenderedTermType, string> gameScriptVarNamePair in character.GameScriptVarNames) {
                GenderedTermType termType = gameScriptVarNamePair.Key;
                string gameScriptVarName = gameScriptVarNamePair.Value;

                string genderedTerm;
                if (!genderedTermsByTermType.TryGetValue(termType, out genderedTerm)) {
                    Debug.LogWarning("Unknown gendered term type \"" + termType.ToString() + "\" for " + character.Name + "not in dictionary.");
                    continue;
                }

                // check if we need to capitalize this gendered term
                if (gameScriptVarName.Contains(DynamicGenderCharacterGameData.CAP_SUFFIX)) {
                    genderedTerm = CapitalizeString(genderedTerm);
                }
                fungusHelper.UpdateVariable(gameScriptVarName, genderedTerm);
            }
        }

        private Pronoun? ReadPronounFromFungusVar(string varName) {
            string pronounString = fungusHelper.GetVariable(varName);

            if (pronounString == null) {
                Debug.LogWarning("Pronoun variable \"" + varName + "\" not found in global variables.");
                return null;
            }

            try {
                return PronounParser.FromString(pronounString);
            } catch (ArgumentException) {
                Debug.LogError("Unsupported pronoun: \"" + pronounString + "\".");
                return null;
            }
        }

        private static string CapitalizeString(string value) {
            return char.ToUpper(value[0]) + value.Substring(1);
        }
    }
}
