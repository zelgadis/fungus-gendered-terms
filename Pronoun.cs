using System;

namespace GenderedTerms {

    // note that if you add a new supported pronoun, you must also update the GenderedTerm and GenderedTermDictionary to handle it
    enum Pronoun {
        HE,
        SHE,
        THEY
    }

    static class PronounParser {
        public static Pronoun FromString(string pronounString) {
            return (Pronoun)Enum.Parse(typeof(Pronoun), pronounString, true);
        }
    }
}
