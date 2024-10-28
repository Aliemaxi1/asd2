private static int EmpowerStateNow = new int();
-----------------------------------------------------------------------------------------------------------------------

public string AllyName1;
public string AllyName2;
public string AllyName3;
public string AllyName4;
                    
public Dictionary<string, int> PartyDict = new Dictionary<string, int>() { };
------------------------------------------------------------------------------------------------------------------------
MISC CHECK

        public bool UnitFocus(string unit)
        {
            if (Aimsharp.CustomFunction("UnitIsFocus") == 1 && unit == "party1" || Aimsharp.CustomFunction("UnitIsFocus") == 2 && unit == "party2" || Aimsharp.CustomFunction("UnitIsFocus") == 3 && unit == "party3" || Aimsharp.CustomFunction("UnitIsFocus") == 4 && unit == "party4" || Aimsharp.CustomFunction("UnitIsFocus") == 5 && unit == "player")
                return true;

            return false;
        }


-----------------------------------------------------------------------------------------------------------

///Macro ADD 
private void InitializeMacros()

Macros.Add("FOC_player", "/focus player");
Macros.Add("FOC_party1", "/focus party1");
Macros.Add("FOC_party2", "/focus party2");
Macros.Add("FOC_party3", "/focus party3");
Macros.Add("FOC_party4", "/focus party4");

for (int i = 1; i <= 40; i++)
{
       Macros.Add("FOC_raid" + i, "/focus raid" + i);
}

Macros.Add("PrescienceFocus", "/cast [@focus] " + Prescience_SpellName(Language));
Macros.Add("BlisteringScalesFocus", "/cast [@focus] " + BlisteringScales_SpellName(Language));

------------------------------------------------------------------------------------------------------------------------
private void InitializeCustomLUAFunctions()

CustomFunctions.Add("AllyPrescienceBuffWithName", "\nlocal out = 0;\nlocal numGroupMembers = GetNumGroupMembers();\nlocal Ally1 = \"" + AllyName1 + "\";\nlocal Ally2 = \"" + AllyName2 + "\";\nlocal Ally3 = \"" + AllyName3 + "\";\nlocal Ally4 = \"" + AllyName4 + "\";\n\nif numGroupMembers > 0 and numGroupMembers < 6 then\n\tfor p = 1, numGroupMembers do\n\t\tlocal partymember = 'party' .. p\n\t\tlocal SpellinRange = IsSpellInRange(\"" + Prescience_SpellName(Language) + "\", partymember)\n\t\tlocal role = UnitGroupRolesAssigned(partymember)\n\t\tlocal hasPrescienceBuff = false;\n\t\tif UnitExists(partymember) and UnitIsDeadOrGhost(partymember) ~= true and SpellinRange == 1 then\n\t\t\tif UnitName(partymember) == Ally1 then\n\t\t\t\tfor i = 1, 25 do\n\t\t\t\t\tlocal name,_,_,_,_,expiration = UnitAura(partymember, i)\n\t\t\t\t\tif expiration ~= nil then\n\t\t\t\t\t\tlocal resttime = expiration - GetTime()\n\t\t\t\t\t\tif name ~= nil and resttime > 6 and name == \"" + Prescience_SpellName(Language) + "\" then\n\t\t\t\t\t\t\thasPrescienceBuff = true;\n\t\t\t\t\t\t\tbreak\n\t\t\t\t\t\tend\n\t\t\t\t\tend\n\t\t\t\tend\n\t\t\t\tif hasPrescienceBuff == false then\n\t\t\t\t\tout = p;\n\t\t\t\t\treturn out;\n\t\t\t\tend\n\t\t\telseif UnitName(partymember) == Ally2 then\n\t\t\t\tfor i = 1, 25 do\n\t\t\t\t\tlocal name,_,_,_,_,expiration = UnitAura(partymember, i)\n\t\t\t\t\tif expiration ~= nil then\n\t\t\t\t\t\tlocal resttime = expiration - GetTime()\n\t\t\t\t\t\tif name ~= nil and resttime > 6 and name == \"" + Prescience_SpellName(Language) + "\" then\n\t\t\t\t\t\t\thasPrescienceBuff = true;\n\t\t\t\t\t\t\tbreak\n\t\t\t\t\t\tend\n\t\t\t\t\tend\n\t\t\t\tend\n\t\t\t\tif hasPrescienceBuff == false then\n\t\t\t\t\tout = p;\n\t\t\t\t\treturn out;\n\t\t\t\tend\n\t\t\telseif UnitName(partymember) == Ally3 then\n\t\t\t\tfor i = 1, 25 do\n\t\t\t\t\tlocal name,_,_,_,_,expiration = UnitAura(partymember, i)\n\t\t\t\t\tif expiration ~= nil then\n\t\t\t\t\t\tlocal resttime = expiration - GetTime()\n\t\t\t\t\t\tif name ~= nil and resttime > 6 and name == \"" + Prescience_SpellName(Language) + "\" then\n\t\t\t\t\t\t\thasPrescienceBuff = true;\n\t\t\t\t\t\t\tbreak\n\t\t\t\t\t\tend\n\t\t\t\t\tend\n\t\t\t\tend\n\t\t\t\tif hasPrescienceBuff == false then\n\t\t\t\t\tout = p;\n\t\t\t\t\treturn out;\n\t\t\t\tend\n\t\t\telseif UnitName(partymember) == Ally4 then\n\t\t\t\tfor i = 1, 25 do\n\t\t\t\t\tlocal name,_,_,_,_,expiration = UnitAura(partymember, i)\n\t\t\t\t\tif expiration ~= nil then\n\t\t\t\t\t\tlocal resttime = expiration - GetTime()\n\t\t\t\t\t\tif name ~= nil and resttime > 6 and name == \"" + Prescience_SpellName(Language) + "\" then\n\t\t\t\t\t\t\thasPrescienceBuff = true;\n\t\t\t\t\t\t\tbreak\n\t\t\t\t\t\tend\n\t\t\t\t\tend\n\t\t\t\tend\n\t\t\t\tif hasPrescienceBuff == false then\n\t\t\t\t\tout = p;\n\t\t\t\t\treturn out;\n\t\t\t\tend\n\t\t\telseif role == \"DAMAGER\" then\n\t\t\t\tfor i = 1, 25 do\n\t\t\t\t\tlocal name,_,_,_,_,expiration = UnitAura(partymember, i)\n\t\t\t\t\tif expiration ~= nil then\n\t\t\t\t\t\tlocal resttime = expiration - GetTime()\n\t\t\t\t\t\tif name ~= nil and resttime > 6 and name == \"" + Prescience_SpellName(Language) + "\" then\n\t\t\t\t\t\t\thasPrescienceBuff = true;\n\t\t\t\t\t\t\tbreak\n\t\t\t\t\t\tend\n\t\t\t\t\tend\n\t\t\t\tend\n\t\t\t\tif hasPrescienceBuff == false then\n\t\t\t\t\tout = p;\n\t\t\t\t\treturn out;\n\t\t\t\tend\n\t\t\tend\n\t\tend\n\tend\n\treturn out;\nelseif numGroupMembers > 5 then\n\tfor r = 1, numGroupMembers do\n\t\tlocal raidmember = 'raid' .. r\n\t\tlocal SpellinRange = IsSpellInRange(\"" + Prescience_SpellName(Language) + "\", raidmember)\n\t\tlocal role = UnitGroupRolesAssigned(raidmember)\n\t\tlocal hasPrescienceBuff = false;\n\t\tlocal hasCDBuff = false;\n\t\tif UnitExists(raidmember) and UnitIsDeadOrGhost(raidmember) ~= true and SpellinRange == 1 then\n\t\t\tif UnitName(raidmember) == Ally1 then\n\t\t\t\tfor i = 1, 25 do\n\t\t\t\t\tlocal name,_,_,_,_,expiration = UnitAura(raidmember, i)\n\t\t\t\t\tif expiration ~= nil then\n\t\t\t\t\t\tlocal resttime = expiration - GetTime()\n\t\t\t\t\t\tif name ~= nil and resttime > 6 and name == \"" + Prescience_SpellName(Language) + "\" then\n\t\t\t\t\t\t\thasPrescienceBuff = true;\n\t\t\t\t\t\t\tbreak\n\t\t\t\t\t\tend\n\t\t\t\t\tend\n\t\t\t\tend\n\t\t\t\tif hasPrescienceBuff == false then\n\t\t\t\t\tout = r;\n\t\t\t\t\treturn out;\n\t\t\t\tend\n\t\t\telseif UnitName(raidmember) == Ally2 then\n\t\t\t\tfor i = 1, 25 do\n\t\t\t\t\tlocal name,_,_,_,_,expiration = UnitAura(raidmember, i)\n\t\t\t\t\tif expiration ~= nil then\n\t\t\t\t\t\tlocal resttime = expiration - GetTime()\n\t\t\t\t\t\tif name ~= nil and resttime > 6 and name == \"" + Prescience_SpellName(Language) + "\" then\n\t\t\t\t\t\t\thasPrescienceBuff = true;\n\t\t\t\t\t\t\tbreak\n\t\t\t\t\t\tend\n\t\t\t\t\tend\n\t\t\t\tend\n\t\t\t\tif hasPrescienceBuff == false then\n\t\t\t\t\tout = r;\n\t\t\t\t\treturn out;\n\t\t\t\tend\n\t\t\telseif UnitName(raidmember) == Ally3 then\n\t\t\t\tfor i = 1, 25 do\n\t\t\t\t\tlocal name,_,_,_,_,expiration = UnitAura(raidmember, i)\n\t\t\t\t\tif expiration ~= nil then\n\t\t\t\t\t\tlocal resttime = expiration - GetTime()\n\t\t\t\t\t\tif name ~= nil and resttime > 6 and name == \"" + Prescience_SpellName(Language) + "\" then\n\t\t\t\t\t\t\thasPrescienceBuff = true;\n\t\t\t\t\t\t\tbreak\n\t\t\t\t\t\tend\n\t\t\t\t\tend\n\t\t\t\tend\n\t\t\t\tif hasPrescienceBuff == false then\n\t\t\t\t\tout = r;\n\t\t\t\t\treturn out;\n\t\t\t\tend\n\t\t\telseif UnitName(raidmember) == Ally4 then\n\t\t\t\tfor i = 1, 25 do\n\t\t\t\t\tlocal name,_,_,_,_,expiration = UnitAura(raidmember, i)\n\t\t\t\t\tif expiration ~= nil then\n\t\t\t\t\t\tlocal resttime = expiration - GetTime()\n\t\t\t\t\t\tif name ~= nil and resttime > 6 and name == \"" + Prescience_SpellName(Language) + "\" then\n\t\t\t\t\t\t\thasPrescienceBuff = true;\n\t\t\t\t\t\t\tbreak\n\t\t\t\t\t\tend\n\t\t\t\t\tend\n\t\t\t\tend\n\t\t\t\tif hasPrescienceBuff == false then\n\t\t\t\t\tout = r;\n\t\t\t\t\treturn out;\n\t\t\t\tend\n\t\t\tend\n\t\tend\n\tend\n\treturn out;\nend\nreturn out;");

CustomFunctions.Add("BlisteringCheck", "local out = 0;\nlocal numGroupMembers = GetNumGroupMembers();\nif numGroupMembers > 0 and numGroupMembers < 6 then\n\tfor p = 1, numGroupMembers do\n\t\tlocal partymember = 'party' .. p\n\t\tlocal SpellinRange = IsSpellInRange(\"" + BlisteringScales_SpellName(Language) + "\", partymember)\n\t\tlocal role = UnitGroupRolesAssigned(partymember)\n\t\tif UnitExists(partymember) and UnitIsDeadOrGhost(partymember) ~= true and SpellinRange == 1 and role == \"TANK\" then\n\t\t\tlocal hasBlistering = false\n\t\t\tfor i = 1, 25 do\n\t\t\t\tlocal name, _, stacks, _, _, _, _, _, _, buffid = UnitAura(partymember, i)\n\t\t\t\tif buffid == 360827 and stacks > 2 then\n\t\t\t\t\thasBlistering = true\n\t\t\t\t\tbreak\n\t\t\t\tend\n\t\t\tend\n\t\t\tif not hasBlistering then\n\t\t\t\tout = p\n\t\t\t\tbreak\n\t\t\tend\n\t\tend\n\tend\nelseif numGroupMembers > 5 then\n\tfor r = 1, numGroupMembers do\n\t\tlocal raidmember = 'raid' .. r\n\t\tlocal SpellinRange = IsSpellInRange(\"" + BlisteringScales_SpellName(Language) + "\", raidmember)\n\t\tlocal role = UnitGroupRolesAssigned(raidmember)\n\t\tif UnitExists(raidmember) and UnitIsDeadOrGhost(raidmember) ~= true and SpellinRange == 1 and role == \"TANK\" then\n\t\t\tlocal hasBlistering = false\n\t\t\tfor i = 1, 25 do\n\t\t\t\tlocal name, _, stacks, _, _, _, _, _, _, buffid = UnitAura(raidmember, i)\n\t\t\t\tif buffid == 360827 and stacks > 2 then\n\t\t\t\t\thasBlistering = true\n\t\t\t\t\tbreak\n\t\t\t\tend\n\t\t\tend\n\t\t\tif not hasBlistering then\n\t\t\t\tout = r\n\t\t\t\tbreak\n\t\t\tend\n\t\tend\n\tend\nend\nreturn out;");

CustomFunctions.Add("UnitIsFocus", "local foc=0; " +
            "\nif UnitExists('focus') and UnitIsUnit('party1','focus') then foc = 1; end" +
            "\nif UnitExists('focus') and UnitIsUnit('party2','focus') then foc = 2; end" +
            "\nif UnitExists('focus') and UnitIsUnit('party3','focus') then foc = 3; end" +
            "\nif UnitExists('focus') and UnitIsUnit('party4','focus') then foc = 4; end" +
            "\nif UnitExists('focus') and UnitIsUnit('player','focus') then foc = 5; end" +
            "\nreturn foc");

/// Empowered Check

CustomFunctions.Add("EmpowermentCheck", "local loading, finished = IsAddOnLoaded(\"Hekili\")\nif loading == true and finished == true then\n    local id,empowermentStage,_=Hekili_GetRecommendedAbility(\"Primary\",1)\n    if id ~= nil and empowermentStage ~= nil and empowermentStage > 0 then\n        return empowermentStage\n    end\nend\nreturn 0");

/// Group Logic 

CustomFunctions.Add("GroupTargets",
            "local UnitTargeted = 0 " +
            "for i = 1, 20 do local unit = 'nameplate'..i " +
                "if UnitExists(unit) then " +
                    "if UnitCanAttack('player', unit) then " +
                        "if GetNumGroupMembers() < 6 then " +
                            "for p = 1, 4 do local partymember = 'party'..p " +
                                "if UnitIsUnit(unit..'target', partymember) then UnitTargeted = p end " +
                            "end " +
                        "end " +
                        "if GetNumGroupMembers() > 5 then " +
                            "for r = 1, GetNumGroupMembers() do local raidmember = 'raid'..r " +
                                "if UnitIsUnit(unit..'target', raidmember) then UnitTargeted = r end " +
                            "end " +
                        "end " +
                        "if UnitIsUnit(unit..'target', 'player') then UnitTargeted = 5 end " +
                    "else UnitTargeted = 0 " +
                    "end " +
                "end " +
            "end " +
            "return UnitTargeted");

------------------------------------------------------------------------------------------------------------------------

// Settings ADD
public override void LoadSettings()
        
Settings.Add(new Setting("Prescience Targets: "));
Settings.Add(new Setting("Ally Name 1: ", ""));
Settings.Add(new Setting("Ally Name 2: ", ""));
Settings.Add(new Setting("Ally Name 3: ", ""));
Settings.Add(new Setting("Ally Name 4: ", ""));
Settings.Add(new Setting("    "));

-----------------------------------------------------------------------------------------------------------------------      

//Bufflist

 m_BuffsList = new List<string> { Prescience_SpellName(Language) };

------------------------------------------------------------------------------------------------------------------------

 public override bool CombatTick()
 #Declearation

 int AllyNumber = Aimsharp.CustomFunction("AllyPrescienceBuffWithName");
 int TankNumber = Aimsharp.CustomFunction("BlisteringCheck");

 int EmpowermentStage = Aimsharp.GetEmpowerStage();
 int EmpowerTo = Aimsharp.CustomFunction("EmpowermentCheck");

-------------------------------------------------------------------------------------------------------------------------

//Prescience Logic

            if (Aimsharp.CanCast(Prescience_SpellName(Language), "player") && Aimsharp.GroupSize() > 0 && AllyNumber > 0)
            {
                //Focus Custom Ally
                if (Aimsharp.GroupSize() > 0 && Aimsharp.GroupSize() < 6)
                {
                    Aimsharp.Cast("FOC_party" + AllyNumber, true);
                    if (Debug)
                    {
                        Aimsharp.PrintMessage("Focusing Partymember - " + AllyNumber + " for Prescience!", Color.DarkGreen);
                    }
                }
                if (Aimsharp.GroupSize() > 5)
                {
                    Aimsharp.Cast("FOC_raid" + AllyNumber, true);
                    if (Debug)
                    {
                        Aimsharp.PrintMessage("Focusing Raidmember - " + AllyNumber + " for Prescience!", Color.DarkGreen);
                    }
                }
                System.Threading.Thread.Sleep(100);
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Prescience on Focus " + AllyNumber, Color.LightGreen);
                }
                Aimsharp.Cast("PrescienceFocus", true);
            }

            if (SpellID1 == 409311 && Aimsharp.CanCast(Prescience_SpellName(Language), "player") && AllyNumber == 0)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Prescience - " + SpellID1 + " because the focus function returned 0.", Color.LightGreen);
                }
                Aimsharp.Cast(Prescience_SpellName(Language), true);
                return true;
            }

-------------------------------------------------------------------------------------------------------------------------------------------------

// Blistering Scales

                    if (SpellID1 == 360827 && CanCastCheck(BlisteringScales_SpellName(Language), "player", false, false))
                    {
                        if (Aimsharp.GroupSize() > 0)
                        {
                            if (Aimsharp.GroupSize() < 6)
                            {
                                Aimsharp.Cast("FOC_party" + TankNumber, true);
                                Aimsharp.PrintMessage("Focusing Tank " + TankNumber, Color.DarkGreen);
                            }
                            if (Aimsharp.GroupSize() > 5)
                            {
                                Aimsharp.Cast("FOC_raid" + TankNumber, true);
                                Aimsharp.PrintMessage("Focusing Tank " + TankNumber, Color.DarkGreen);
                            }
                            if (Debug)
                            {
                                Aimsharp.PrintMessage("Casting Blistering Scales - " + SpellID1 + " on Focus " + TankNumber, Color.LightGreen);
                            }
                            Aimsharp.Cast("BlisteringScalesFocus", true);
                        }
                        else
                        {
                            if (Debug)
                            {
                                Aimsharp.PrintMessage("Casting Blistering Scales - " + SpellID1, Color.LightGreen);
                            }
                            Aimsharp.Cast(BlisteringScales_SpellName(Language));
                            return true;
                        }
                        return true;
                    }


-------------------------------------------------------------------------------------------------------------------------------------------------





