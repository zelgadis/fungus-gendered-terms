# fungus-gendered-terms

Made by **Just Us Games**, creators of **Supreme Courtship**, and (soon!) other political comedy games.
https://supremecourtship.com

An add-on for Fungus that simplifies the process of writing for characters with a dynamic or user-defined gender. We take the user's gender pronoun, and use it to determine the gendered terms for that pronoun. These are then added to Fungus as variables, which can be used in your game's script.

Tested with:
* Unity - 2018.2.21f1
* Fungus - 3.11.2
* Visual Studio - Mono 5.18.1.3


### Usage example:

**Game script:** "That's {$GT_him} over there."

**Fungus variables:** mc_pronoun = "she"

**Result:** "That's her over there."

*(Supported pronouns: he, she, they)*


## === INSTRUCTIONS: HELLO WORLD ===

### SETUP:
1. Add the code to your project.
2. Add a new GameObject to the scene hierarchy. Add the GenderedTermLoader as a Component.
3. Update the *DynamicGenderCharacterGameData* for your game.
    1. Specify the Fungus variable that will store the character's pronoun (ie "mc_pronoun").
    2. Specify the kinds of gendered terms used in your game script for this character, and the variable names for them.

### USAGE:
1. Update your game script to use the Fungus variables for your characters (ie {$GT_him}).
2. Set the Fungus variables that store your character pronouns to the correct values (ie mc_pronoun = "she").
3. On Start(), the GenderedTermLoader will add the gendered terms for each character to Fungus as global variables (ie {$GT_him} -> "him", "her", or "them").
    1. If a character's pronoun changes after Start(), call "UpdateAllGenderedTermVariables()" from a Fungus command.


## === INSTRUCTIONS: ADDING GENDERED TERMS ===

1. Update *GenderedTermDictionary.cs*. Add the new type of gendered term as a GenderedTermType enum.
    1. Each new GenderedTermType will need to include terms for each of the supported pronouns.


## === INSTRUCTIONS: ADDING PRONOUNS ===

1. Update *Pronoun.cs*. Add a new Pronoun enum.
2. Add support for the new pronoun.
    1. In *GenderedTerms.cs*, add the new pronoun to GenderedTermTypeAttr and GenderedTerms.
    2. In *GenderedTermDictionary.cs*, update each GenderedTermType enum to include a gendered term for the new pronoun.
