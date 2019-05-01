using System.Collections.Generic;

namespace GenderedTerms {

    class DynamicGenderCharacter {
        public string Name { get; private set; }
        public string PronounVarName { get; private set; }
        public List<KeyValuePair<GenderedTermType, string>> GameScriptVarNames { get; private set; }

        public DynamicGenderCharacter(string name,
                                      string pronounVarName,
                                      List<KeyValuePair<GenderedTermType, string>> gameScriptVarNames) {
            this.Name = name;
            this.PronounVarName = pronounVarName;
            this.GameScriptVarNames = gameScriptVarNames;
        }
    }
}
