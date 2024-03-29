# More Random Seeds
![Mod Version](https://img.shields.io/badge/Mod_Version-7.0-blue.svg)
![RimWorld Version](https://img.shields.io/badge/Built_for_RimWorld-1.4-blue.svg)
![Harmony Version](https://img.shields.io/badge/Powered_by_Harmony-2.2-blue.svg)\
![Steam Subscribers](https://img.shields.io/badge/dynamic/xml.svg?label=Steam+Subscribers&query=//table/tr[2]/td[1]&colorB=blue&url=https://steamcommunity.com/sharedfiles/filedetails/%3Fid=1501463043&suffix=+total)
![GitHub Downloads](https://img.shields.io/github/downloads/Jaxe-Dev/MoreRandomSeeds/total.svg?colorB=blue&label=GitHub+Downloads)

[Link to Steam Workshop page](https://steamcommunity.com/sharedfiles/filedetails/?id=1501463043)\
[Link to Ludeon Forum Post](https://ludeon.com/forums/index.php?topic=43925.0)

---

Alters the Randomize seed button when creating a new world. Instead of a single word, seeds can be generated in a variety of custom formats with random digits or letters.

---

##### STEAM INSTALLATION
- **[Go to the Steam Workshop page](https://steamcommunity.com/sharedfiles/filedetails/?id=1501463043) and subscribe to the mod.**

---

##### NON-STEAM INSTALLATION
- **[Download the latest release](https://github.com/Jaxe-Dev/MoreRandomSeeds/releases/latest) and unzip it into your *RimWorld/Mods* folder.**

---

The following base methods are patched with Harmony:
```
Postfix : RimWorld.Dialog_ModSettings.ctor
Prefix* : Verse.GenText.RandomSeedString
```
A prefix marked by a \* denotes that in some circumstances the original method will be bypassed
