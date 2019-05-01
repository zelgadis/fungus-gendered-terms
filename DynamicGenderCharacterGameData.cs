using System.Collections.Generic;

namespace GenderedTerms {

    class DynamicGenderCharacterGameData {
        public const string CAP_SUFFIX = "_cap";

        /*
         * The main character of Supreme Courtship!
         * Here we specify the variable that we check to figure out the character's pronoun ("mc_pronoun").
         * We also specify the variables used in the game script for this character.
         * 
         * The game script variable names include the "he" option for each term type,
         * to make it easier for humas to read the game script when the vars are included,
         * and to make it easier to take a "dumb" game script and add vars.
         * In some cases the "he" option is ambiguous between term types, so the var name has to be longer to disambiguate.
         * 
         * Also note that capitalized terms need their own variable.
         * These should have the CAP_SUFFIX appended to them, so that the GenderedTermLoader knows to capitalize the term correctly
         */
        private static DynamicGenderCharacter MAIN_CHARACTER = new DynamicGenderCharacter(
            "Main Character",
            "mc_pronoun",
            new List<KeyValuePair<GenderedTermType, string>>() {
                new KeyValuePair<GenderedTermType, string>(GenderedTermType.THIRD_PERS_SUBJECT,             "GT_he"),
                new KeyValuePair<GenderedTermType, string>(GenderedTermType.THIRD_PERS_SUBJECT,             "GT_he" + CAP_SUFFIX), //GT_he_cap
                new KeyValuePair<GenderedTermType, string>(GenderedTermType.THIRD_PERS_SUBJECT_CONTRACTION, "GT_hes"),
                new KeyValuePair<GenderedTermType, string>(GenderedTermType.THIRD_PERS_SUBJECT_CONTRACTION, "GT_hes" + CAP_SUFFIX), //GT_hes_cap
                new KeyValuePair<GenderedTermType, string>(GenderedTermType.THIRD_PERS_OBJECT,              "GT_him"),
                new KeyValuePair<GenderedTermType, string>(GenderedTermType.THIRD_PERS_POSSESSIVE_ADJ,      "GT_his_poss_adj"),
                new KeyValuePair<GenderedTermType, string>(GenderedTermType.THIRD_PERS_POSSESSIVE_PRONOUN,  "GT_his_poss_pro"),
                new KeyValuePair<GenderedTermType, string>(GenderedTermType.THIRD_PERS_REFL_PRONOUN,        "GT_himself"),
                new KeyValuePair<GenderedTermType, string>(GenderedTermType.HONORIFIC_01,                   "GT_sir"),
                new KeyValuePair<GenderedTermType, string>(GenderedTermType.HONORIFIC_01,                   "GT_sir" + CAP_SUFFIX)}); //GT_sir_cap

        private static List<DynamicGenderCharacter> DYNAMIC_GENDER_CHARACTERS = new List<DynamicGenderCharacter> {
            MAIN_CHARACTER
        };

        public static List<DynamicGenderCharacter> GetCharacters() {
            return DYNAMIC_GENDER_CHARACTERS;
        }
    }
}
