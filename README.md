# Unity co-op sample (expanded)

This is expanded version of Unity co-op sample where new mana regeneration aura skill is added to mage class.

In this version mana cost for spells wasn't present so in order for mana regeneration aura to work properly I had to add actual mana usage for spells and attacks.
Also I added mana bar to reflect state of mana of each player.

At the moment there is new spell in mage toolbar which is activated with button "3". It works as a toggle and switches on/off a mana regeneration aura.

Settings for aura can be found in SO called: "ManaRegenerationAura" which can be found in Assets > GameData > Action > Mage

As for now relevant settings are:

<b>Amount</b> - amount of mana regenerated per tick

<b>Aura tick seconds</b> - interval which states how often aura ticks

<b>Radius</b> - range of aura
