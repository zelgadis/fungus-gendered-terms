using System;
using System.Collections.Generic;

namespace GenderedTerms {

    class GenderedTermDictionary {
        private readonly static GenderedTermType[] GENDERED_TERM_TYPES = (GenderedTermType[]) Enum.GetValues(typeof(GenderedTermType));

        public static Dictionary<GenderedTermType, string> GetGenderedTermsForPronoun(Pronoun pronoun) {
            Dictionary<GenderedTermType, string> genderedExpressionDict = new Dictionary<GenderedTermType, string>();

            foreach (GenderedTermType type in GENDERED_TERM_TYPES) {
                genderedExpressionDict[type] = type.GetTerm(pronoun);
            }

            return genderedExpressionDict;
        }
    }

    /*
     * Gendered Term Types - pronouns, honorifics, turns of phrase, etc. that should change depending on a character's gender
     * These should all be lowercase - the code will take care of creating a capitalized version
     */
    enum GenderedTermType {
        [GenderedTermTypeAttr("he", "she", "they")] THIRD_PERS_SUBJECT,                     // "He will go."
        [GenderedTermTypeAttr("he's", "she's", "they're")] THIRD_PERS_SUBJECT_CONTRACTION,  // "They're already there."
        [GenderedTermTypeAttr("him", "her", "them")] THIRD_PERS_OBJECT,                     // "Max saw her."
        [GenderedTermTypeAttr("his", "her", "their")] THIRD_PERS_POSSESSIVE_ADJ,            // "That's his name."
        [GenderedTermTypeAttr("his", "hers", "theirs")] THIRD_PERS_POSSESSIVE_PRONOUN,      // "The car is hers."
        [GenderedTermTypeAttr("himself", "herself", "themself")] THIRD_PERS_REFL_PRONOUN,   // "They saw themself in the mirror."
        [GenderedTermTypeAttr("sir", "ma'am", "honored guest")] HONORIFIC_01,               // "Hello, sir!"
    }
}
