using Fungus;
using System;

namespace GenderedTerms {

    /*
     * Helper class for interfacing with Fungus
     * Tested against Fungus 3.11.2    
     */
    sealed class FungusHelper {
        private static readonly FungusHelper instance = new FungusHelper();

        // Explicit static constructor to tell C# compiler not to mark type as beforefieldinit
        static FungusHelper() {
        }

        private GlobalVariables globalVars;

        private FungusHelper() {
            this.globalVars = FungusManager.Instance.GlobalVariables;
        }

        public static FungusHelper Instance {
            get {
                return instance;
            }
        }

        public string GetVariable(string varName) {
            StringVariable stringVar = globalVars.GetVariable(varName) as StringVariable;
            if (stringVar == null) {
                return null;
            } else {
                return stringVar.Value;
            }
        }

        public void UpdateVariable(string varName, string varValue) {
            StringVariable stringVar = globalVars.GetOrAddVariable<String>(varName, varValue, typeof(StringVariable)) as StringVariable;

            // GetOrAddVariable doesn't always update the variable to the given value (in the case of a Get)
            // so we have to do it ourselves
            stringVar.Value = varValue;
        }
    }
}
