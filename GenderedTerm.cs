using System;
using System.ComponentModel;
using System.Reflection;

namespace GenderedTerms {

    class GenderedTermTypeAttr : Attribute {
        public string HeTerm { get; private set; }
        public string SheTerm { get; private set; }
        public string TheyTerm { get; private set; }

        internal GenderedTermTypeAttr(string heTerm,
                                      string sheTerm,
                                      string theyTerm) {
            this.HeTerm = heTerm;
            this.SheTerm = sheTerm;
            this.TheyTerm = theyTerm;
        }
    }

    static class GenderedTerms {
        /// <exception cref="InvalidEnumArgumentException">Thrown if a valid Pronoun is passed in without being supported</exception>
        public static string GetTerm(this GenderedTermType t, Pronoun pronoun) {
            GenderedTermTypeAttr attr = GetAttr(t);

            switch (pronoun) {
                case Pronoun.HE: return attr.HeTerm;
                case Pronoun.SHE: return attr.SheTerm;
                case Pronoun.THEY: return attr.TheyTerm;
                default: throw new InvalidEnumArgumentException("Unsupported pronoun: \"" + pronoun.ToString() + "\"");
            }
        }

        private static GenderedTermTypeAttr GetAttr(GenderedTermType t) {
            return (GenderedTermTypeAttr)Attribute.GetCustomAttribute(ForValue(t), typeof(GenderedTermTypeAttr));
        }

        private static MemberInfo ForValue(GenderedTermType t) {
            return typeof(GenderedTermType).GetField(Enum.GetName(typeof(GenderedTermType), t));
        }
    }
}
