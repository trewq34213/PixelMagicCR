// winifix@gmail.com
// ReSharper disable UnusedMember.Global
// ReSharper disable ConvertPropertyToExpressionBody

using System.Diagnostics;
using System;
using PixelMagic.Helpers;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using PixelMagic.GUI;
using System.IO;

namespace PixelMagic.Rotation
{
    public class HunterMarksman : CombatRoutine
    {		
	
	bool FourTarget = false;
	
        private CheckBox BarrageBox;
        private CheckBox CrowBox;
        private CheckBox dpscooldownsBox;
        private CheckBox TurtleBox;
        private CheckBox DeathBox;
        private CheckBox ExhilBox;
		private CheckBox CounterShotBox;		

        public override Form SettingsForm { get; set; }

        public override void Initialize()
        {

            Log.Write("Welcome to Hunter Beastmastery by Goat", Color.Green);
            WoW.Speak("Welcome to Pixelmagic Beastmastery Rotation by Goat");

            SettingsForm = new Form
            {
                Text = "Settings",
                StartPosition = FormStartPosition.CenterScreen,
                Width = 480,
                Height = 300,
                ShowIcon = false
            };

            var picBox = new PictureBox
            {
                Left = 0,
                Top = 0,
                Width = 800,
                Height = 100,
                Image = TopLogo
            };
            SettingsForm.Controls.Add(picBox);

            var lblBarrageText = new Label //Barrage LABEL - 114
            {
                Text = "Barrage",
                Size = new Size(81, 13),
                Left = 12,
                Top = 114
            };
            SettingsForm.Controls.Add(lblBarrageText); //Barrage TEXT - 114

            BarrageBox = new CheckBox
            {
                Checked = Barrage,
                TabIndex = 2,
                Size = new Size(15, 14),
                Left = 115,
                Top = 114
            };
            SettingsForm.Controls.Add(BarrageBox); //Barrage BOX	
			
            var lbldpscooldownsText = new Label //Trueshot LABEL - 129
            {
                Text = "dpscooldowns",
                Size = new Size(81, 13),
                Left = 12,
                Top = 129
            };
            SettingsForm.Controls.Add(lbldpscooldownsText); //Trueshot TEXT - 129

            dpscooldownsBox = new CheckBox
            {
                Checked = dpscooldowns,
                TabIndex = 4,
                Size = new Size(15, 14),
                Left = 115,
                Top = 129
            };
            SettingsForm.Controls.Add(dpscooldownsBox);	//Trueshot BOX	

            var lblCrowText = new Label  // Crow LABEL
            {
                Text = "Crow",
                Size = new Size(81, 13),
                Left = 12,
                Top = 145
            };
            SettingsForm.Controls.Add(lblCrowText); //Crow TEXT

            CrowBox = new CheckBox
            {
                Checked = Crow,
                TabIndex = 6,
                Size = new Size(15, 14),
                Left = 115,
                Top = 145
            };
            SettingsForm.Controls.Add(CrowBox);   // Crow BOX

            var lblExhilText = new Label  // Exhil LABEL
            {
                Text = "Exhil",
                Size = new Size(81, 13),
                Left = 12,
                Top = 161
            };
            SettingsForm.Controls.Add(lblExhilText); //EXHIL TEXT

            ExhilBox = new CheckBox
            {
                Checked = Exhil,
                TabIndex = 8,
                Size = new Size(15, 14),
                Left = 115,
                Top = 161
            };
            SettingsForm.Controls.Add(ExhilBox); //Exhil Box

            var lblTurtleText = new Label //Turtle label
            {
                Text = "Turtle",
                Size = new Size(81, 13),
                Left = 12,
                Top = 178
            };
            SettingsForm.Controls.Add(lblTurtleText);  //turtle text

            TurtleBox = new CheckBox
            {
                Checked = Turtle,
                TabIndex = 10,
                Size = new Size(15, 14),
                Left = 115,
                Top = 178
            };
            SettingsForm.Controls.Add(TurtleBox);   //turtle box

            var lblDeathText = new Label //Death label
            {
                Text = "Death",
                Size = new Size(81, 13),
                Left = 12,
                Top = 194
            };
            SettingsForm.Controls.Add(lblDeathText); //death text

            DeathBox = new CheckBox
            {
                Checked = Death,
                TabIndex = 12,
                Size = new Size(15, 14),
                Left = 115,
                Top = 194
            };
            SettingsForm.Controls.Add(DeathBox);   //death box	
			
            var lblCounterShotText = new Label //CounterShot label
            {
                Text = "CounterShot",
                Size = new Size(81, 13),
                Left = 12,
                Top = 210
            };
            SettingsForm.Controls.Add(lblCounterShotText); //CounterShot text

            CounterShotBox = new CheckBox
            {
                Checked = CounterShot,
                TabIndex = 12,
                Size = new Size(15, 14),
                Left = 115,
                Top = 210
            };
            SettingsForm.Controls.Add(CounterShotBox);   //CounterShot box			

            var cmdSave = new Button
            {
                Text = "Save",
                Width = 65,
                Height = 25,
                Left = 332,
                Top = 190,
                Size = new Size(120, 31)
            };

            BarrageBox.Checked = Barrage;
            CrowBox.Checked = Crow;
            DeathBox.Checked = Death;
            ExhilBox.Checked = Exhil;  
			dpscooldownsBox.Checked = dpscooldowns;
            TurtleBox.Checked = Turtle;
            CounterShotBox.Checked = CounterShot;			

            cmdSave.Click += CmdSave_Click;
            BarrageBox.CheckedChanged += Barrage_Click;
            CrowBox.CheckedChanged += Crow_Click;
            DeathBox.CheckedChanged += Death_Click;
            TurtleBox.CheckedChanged += Turtle_Click;
            ExhilBox.CheckedChanged += Exhil_Click; 
			dpscooldownsBox.CheckedChanged += dpscooldowns_Click;
            CounterShotBox.CheckedChanged += CounterShot_Click;			

            SettingsForm.Controls.Add(cmdSave);
            lblBarrageText.BringToFront();
            lblCrowText.BringToFront();           
            lblExhilText.BringToFront();
			lbldpscooldownsText.BringToFront();
            lblDeathText.BringToFront();
            lblTurtleText.BringToFront();
            lblCounterShotText.BringToFront();			

            Log.Write("Barrage = " + Barrage);
            Log.Write("Crow = " + Crow);
            Log.Write("Exhil = " + Exhil);
            Log.Write("Death = " + Death);
            Log.Write("Turtle = " + Turtle);
			Log.Write("dpscooldowns = " + dpscooldowns);
            Log.Write("CounterShot = " + CounterShot);			
        }

        private void CmdSave_Click(object sender, EventArgs e)
        {
            Barrage = BarrageBox.Checked;
            Crow = CrowBox.Checked;
            Exhil = ExhilBox.Checked;
            Death = DeathBox.Checked;         
            Turtle = TurtleBox.Checked;
			dpscooldowns = dpscooldownsBox.Checked;
            CounterShot = CounterShotBox.Checked;			
            MessageBox.Show("Settings saved", "PixelMagic", MessageBoxButtons.OK, MessageBoxIcon.Information);
            SettingsForm.Close();
        }

        private void Barrage_Click(object sender, EventArgs e)
        {
            Barrage = BarrageBox.Checked;
        }

        private void Crow_Click(object sender, EventArgs e)
        {
            Crow = CrowBox.Checked;
        }
        private void Death_Click(object sender, EventArgs e)
        {
            Death = DeathBox.Checked;
        }
        private void Exhil_Click(object sender, EventArgs e)
        {
            Exhil = ExhilBox.Checked;
        }
        private void Turtle_Click(object sender, EventArgs e)
        {
            Turtle = TurtleBox.Checked;
        }
		private void dpscooldowns_Click(object sender, EventArgs e)
        {
            dpscooldowns = dpscooldownsBox.Checked;
        }
        private void CounterShot_Click(object sender, EventArgs e)
        {
            CounterShot = CounterShotBox.Checked;
        }	

        private readonly Stopwatch interruptwatch = new Stopwatch();
		private readonly Stopwatch multishotwatch = new Stopwatch();	

        public override void Stop()
        {
        }


public override void Pulse() 
        {
            if (combatRoutine.Type == RotationType.SingleTarget)  // Do Single Target Stuff here
            {
	
                    if (WoW.CanCast("Death") && WoW.HealthPercent < 40 && Death && !WoW.IsSpellOnCooldown("Death") && WoW.HealthPercent != 0)
                    {
                        WoW.CastSpell("Death");
                        return;
                    }
                    if (WoW.CanCast("Exhil") && WoW.HealthPercent < 30 && Exhil && !WoW.IsSpellOnCooldown("Exhil") && WoW.HealthPercent != 0)
                    {
                        WoW.CastSpell("Exhil");
                        return;
                    }	
					if (WoW.CanCast("Turtle") && WoW.HealthPercent < 20 && Turtle && !WoW.IsSpellOnCooldown("Turtle") && WoW.HealthPercent != 0)
                    {
                        WoW.CastSpell("Turtle");
                        return;
                    }
					/*if (WoW.CanCast("Ancient Healing Potion") && WoW.HealthPercent < 20 && !WoW.IsSpellOnCooldown("Ancient Healing Potion") && WoW.HealthPercent != 0)
						{
							WoW.CastSpell("Ancient Healing Potion");
							return;
						}
					/*if (WoW.CanCast("Silkweave Bandage") && WoW.HealthPercent < 40 && WoW.PlayerHasBuff("Turtle") && !WoW.IsMoving && !WoW.PlayerHasDebuff("Bandaged") && WoW.HealthPercent != 0)
						{
							WoW.CastSpell("Silkweave Bandage");
							return;
						}*/
											
                if (WoW.HasTarget && WoW.TargetIsEnemy && WoW.IsInCombat)
                {	

					if (!WoW.HasPet && WoW.CanCast("Wolf"))
					{
						WoW.CastSpell("Wolf") ;
						return;
					}
					if (WoW.PetHealthPercent <= 0 && WoW.CanCast("Phoenix"))
					{
						WoW.CastSpell("Phoenix") ;
						return;
					}					
					if (WoW.PetHealthPercent <= 0 && WoW.IsSpellOnCooldown("Phoenix") && WoW.CanCast("Revive Pet") && !WoW.IsMoving)
					{
						WoW.CastSpell("Revive Pet") ;
						return;
					}
								
					/*if (WoW.CanCast("Ring") && !WoW.IsSpellOnCooldown("Ring") && !WoW.PlayerHasDebuff("Temptation"))
                    {
						WoW.CastSpell("Ring");
						return;
					}	*/
                    if (WoW.TargetIsCasting && CounterShot && interruptwatch.ElapsedMilliseconds == 0)
                    {
						interruptwatch.Start ();
						Log.WritePixelMagic("interruptwatch started..", Color.Black);	
						return;
					}			
                    if (WoW.CanCast("A Murder of Crows")  && !WoW.IsSpellOnCooldown("A Murder of Crows") && Crow && WoW.IsSpellInRange("A Murder of Crows") && WoW.Focus >= 30  && !(WoW.SpellCooldownTimeRemaining("Bestial Wrath") <= 10))
                    {
                        WoW.CastSpell("A Murder of Crows");
                        return;
                    }				
                    if (WoW.TargetIsCasting && CounterShot && interruptwatch.ElapsedMilliseconds > 800)
                    {
                        if (WoW.CanCast("Counter Shot") && !WoW.IsSpellOnCooldown("Counter Shot") && CounterShot && !WoW.PlayerIsChanneling && !WoW.WasLastCasted("Counter Shot"))
                        {
                            WoW.CastSpell("Counter Shot");
                            interruptwatch.Reset();
							Log.WritePixelMagic("interruptwatch reset!", Color.Black);							
                            interruptwatch.Start();
							Log.WritePixelMagic("interruptwatch started...", Color.Black);							
                            return;
                        }	
					}	
					if (WoW.CanCast("Bestial Wrath") && WoW.Focus >= 100 && WoW.IsSpellInRange("Cobra Shot") && !WoW.PlayerHasBuff("Turtle") && !WoW.IsSpellOnCooldown("Bestial Wrath") && !(WoW.SpellCooldownTimeRemaining("Kill Command") >= 3))
                    {
                        WoW.CastSpell("Bestial Wrath");
                        return;
                    }
					if (WoW.CanCast("Aspect of the Wild") && !WoW.IsSpellOnCooldown("Aspect of the Wild")  && WoW.PlayerHasBuff("Bestial Wrath") && WoW.PlayerBuffTimeRemaining("Bestial Wrath") >= 10 && (dpscooldowns || WoW.PlayerHasBuff("Bloodlust") || WoW.PlayerHasBuff("Ancient Hysteria") || WoW.PlayerHasBuff("Netherwinds") || WoW.PlayerHasBuff("Drums") || WoW.PlayerHasBuff("Heroism") || WoW.PlayerHasBuff("Time Warp") )) 
                    {
                        WoW.CastSpell("Aspect of the Wild");
						WoW.CastSpell("Blood Fury");
						return;
                    }	
					//if (WoW.CanCast("Potion Power") && !WoW.IsSpellOnCooldown("Potion Power") && !WoW.PlayerHasBuff("Potion Power") && (WoW.PlayerHasBuff("Bloodlust") || WoW.PlayerHasBuff("Ancient Hysteria") || WoW.PlayerHasBuff("Netherwinds") || WoW.PlayerHasBuff("Drums") || WoW.PlayerHasBuff("Heroism") || WoW.PlayerHasBuff("Time Warp")))
					//{
						//WoW.CastSpell("Potion Power");
						//return;
					//}
					if (WoW.CanCast("Kill Command") && WoW.Focus >= 100 && WoW.IsSpellInRange("Kill Command"))
                    {
                        WoW.CastSpell("Kill Command");
                        return;
                    }
                    if (WoW.CanCast("Dire Beast") && WoW.IsSpellInRange("Dire Beast") && !WoW.IsSpellOnCooldown("Dire Beast") && !(WoW.SpellCooldownTimeRemaining("Bestial Wrath") <= 2))
                    {
                        WoW.CastSpell("Dire Beast");
						if (WoW.CanCast("Titan's Thunder") && !WoW.IsSpellOnCooldown("Titan's Thunder"))
						{
                        WoW.CastSpell("Titan's Thunder");
                        return;
						}
                    }
                    if (WoW.CanCast("Kill Command") && WoW.Focus >= 30 && WoW.IsSpellInRange("Kill Command"))
                    {
                        WoW.CastSpell("Kill Command");
                        return;
                    }
					if (WoW.CanCast("Cobra Shot") && (WoW.Focus >= 40) && WoW.IsSpellInRange("Cobra Shot") && WoW.PlayerHasBuff("Bestial Wrath") && (WoW.SpellCooldownTimeRemaining("Kill Command") >= 3))
                    {
                        WoW.CastSpell("Cobra Shot");
                        return;
                    }					
					if (WoW.CanCast("Cobra Shot") && (WoW.Focus >= 110) && WoW.IsSpellInRange("Cobra Shot") && ((WoW.SpellCooldownTimeRemaining("Bestial Wrath") >= 1) || (WoW.SpellCooldownTimeRemaining("Kill Command") >= 1) || (WoW.SpellCooldownTimeRemaining("Dire Beast") >= 1) || (WoW.SpellCooldownTimeRemaining("A Murder of Crows") >= 1)))
                    {
                        WoW.CastSpell("Cobra Shot");
                        return;
                    }
					if (WoW.CanCast("Cobra Shot") && (WoW.Focus >= 120) && WoW.IsSpellInRange("Cobra Shot"))
                    {
                        WoW.CastSpell("Cobra Shot");
                        return;
                    }
                }
            }
            if (combatRoutine.Type == RotationType.AOE)
            {
				
                    if (WoW.CanCast("Death") && WoW.HealthPercent < 40 && Death && !WoW.IsSpellOnCooldown("Death") && WoW.HealthPercent != 0)
                    {
                        WoW.CastSpell("Death");
                        return;
                    }
                    if (WoW.CanCast("Exhil") && WoW.HealthPercent < 30 && Exhil && !WoW.IsSpellOnCooldown("Exhil") && WoW.HealthPercent != 0)
                    {
                        WoW.CastSpell("Exhil");
                        return;
                    }	
					if (WoW.CanCast("Turtle") && WoW.HealthPercent < 20 && Turtle && !WoW.IsSpellOnCooldown("Turtle") && WoW.HealthPercent != 0)
                    {
                        WoW.CastSpell("Turtle");
                        return;
                    }
					if (WoW.CanCast("Ancient Healing Potion") && WoW.HealthPercent < 20 && !WoW.IsSpellOnCooldown("Ancient Healing Potion") && WoW.HealthPercent != 0)
						{
							WoW.CastSpell("Ancient Healing Potion");
							return;
						}
					/*if (WoW.CanCast("Silkweave Bandage") && WoW.HealthPercent < 40 && WoW.PlayerHasBuff("Turtle") && !WoW.IsMoving && !WoW.PlayerHasDebuff("Bandaged"))
						{
							WoW.CastSpell("Silkweave Bandage");
							return;
						}	*/
					
                if (WoW.HasTarget && WoW.TargetIsEnemy && WoW.IsInCombat)
                {
                    if (!WoW.HasPet && WoW.CanCast("Wolf"))
					{
						WoW.CastSpell("Wolf") ;
						return;
					}
					if (WoW.PetHealthPercent <= 0 && WoW.CanCast("Phoenix"))
					{
						WoW.CastSpell("Phoenix") ;
						return;
					}					
					if (WoW.PetHealthPercent <= 0 && WoW.IsSpellOnCooldown("Phoenix") && WoW.CanCast("Revive Pet") && !WoW.IsMoving)
					{
						WoW.CastSpell("Revive Pet") ;
						return;
					}
					/*if (WoW.CanCast("Ring") && !WoW.IsSpellOnCooldown("Ring") && !WoW.PlayerHasDebuff("Temptation"))
                    {
						WoW.CastSpell("Ring");
						return;
					}	*/		
                    if (WoW.TargetIsCasting && CounterShot && interruptwatch.ElapsedMilliseconds == 0)
                    {
						interruptwatch.Start ();
						Log.WritePixelMagic("interruptwatch started..", Color.Black);	
						return;
					}															
                    if (WoW.TargetIsCasting && CounterShot && interruptwatch.ElapsedMilliseconds > 800)
                    {
                        if (WoW.CanCast("Counter Shot") && !WoW.IsSpellOnCooldown("Counter Shot") && CounterShot && !WoW.PlayerIsChanneling && !WoW.WasLastCasted("Counter Shot"))
                        {
                            WoW.CastSpell("Counter Shot");
                            interruptwatch.Reset();
							Log.WritePixelMagic("interruptwatch reset!", Color.Black);							
                            interruptwatch.Start();
							Log.WritePixelMagic("interruptwatch started...", Color.Black);							
                            return;
                        }	
					}						
                    if (WoW.CanCast("Multi-Shot") && WoW.PlayerHasBuff("Bestial Wrath") && !(WoW.PetHasBuff("Beast Cleave") || WoW.PetBuffTimeRemaining("Beast Cleave") <= 2) && WoW.IsSpellInRange("Multi-Shot") && WoW.Focus >= 34)
                    {
                        WoW.CastSpell("Multi-Shot");                        
                        return;
                    }
                    if (WoW.CanCast("Multi-Shot") && !(WoW.PetHasBuff("Beast Cleave") || WoW.PetBuffTimeRemaining("Beast Cleave") <= 2) && WoW.IsSpellInRange("Multi-Shot") && !WoW.CanCast("Bestial Wrath") && WoW.Focus >= 40)
                    {
                        WoW.CastSpell("Multi-Shot");                        
                        return;
                    }
					if (WoW.CanCast("A Murder of Crows") && !WoW.IsSpellOnCooldown("A Murder of Crows") && Crow && WoW.IsSpellInRange("A Murder of Crows") && WoW.PetHasBuff("Beast Cleave") && WoW.PetBuffTimeRemaining("Beast Cleave") >= 1&& WoW.Focus >= 30 && !(DetectKeyPress.GetKeyState(0x5A) < 0) && !(WoW.SpellCooldownTimeRemaining("Bestial Wrath") <= 10))
                    {
                        WoW.CastSpell("A Murder of Crows");
                        return;
                    }
                    if (WoW.CanCast("Barrage") && Barrage && WoW.IsSpellInRange("Barrage") && WoW.Focus >= 60)
                    {
                        WoW.CastSpell("Barrage");
                        return;
                    }					
					if (WoW.CanCast("Bestial Wrath") && WoW.IsSpellInRange("Cobra Shot") && !WoW.PlayerHasBuff("Turtle") && !WoW.IsSpellOnCooldown("Bestial Wrath") && !(WoW.SpellCooldownTimeRemaining("Kill Command") >= 3))
                    {
                        WoW.CastSpell("Bestial Wrath");
                        return;
                    }
					if (WoW.CanCast("Aspect of the Wild") && !WoW.IsSpellOnCooldown("Aspect of the Wild")  && WoW.PlayerHasBuff("Bestial Wrath") && (dpscooldowns || WoW.PlayerHasBuff("Bloodlust") || WoW.PlayerHasBuff("Ancient Hysteria") || WoW.PlayerHasBuff("Netherwinds") || WoW.PlayerHasBuff("Drums") || WoW.PlayerHasBuff("Heroism") || WoW.PlayerHasBuff("Time Warp") )) 
                    {
                        WoW.CastSpell("Aspect of the Wild");
						WoW.CastSpell("Blood Fury");
						return;
                    }	
					//if (WoW.CanCast("Potion Power") && !WoW.IsSpellOnCooldown("Potion Power") && !WoW.PlayerHasBuff("Potion Power") && (WoW.PlayerHasBuff("Bloodlust") || WoW.PlayerHasBuff("Ancient Hysteria") || WoW.PlayerHasBuff("Netherwinds") || WoW.PlayerHasBuff("Drums") || WoW.PlayerHasBuff("Heroism") || WoW.PlayerHasBuff("Time Warp")))
					//{
						//WoW.CastSpell("Potion Power");
						//return;
					//}
					if (WoW.CanCast("Dire Beast") && WoW.IsSpellInRange("Dire Beast") && !WoW.IsSpellOnCooldown("Dire Beast") && !(WoW.SpellCooldownTimeRemaining("Bestial Wrath") <= 2))
                    {
                        WoW.CastSpell("Dire Beast");
						if (WoW.CanCast("Titan's Thunder") && !WoW.IsSpellOnCooldown("Titan's Thunder"))
						{
                        WoW.CastSpell("Titan's Thunder");
                        return;
						}
                    }		//Z Key Multi Shot Spam			
					if (WoW.CanCast("Multi-Shot") && (WoW.Focus >= 40) && WoW.IsSpellInRange("Multi-Shot") && (DetectKeyPress.GetKeyState(0x5A) < 0))  //Z key press
{
                            WoW.CastSpell("Multi-Shot");
                            return;
                        }
                    if (WoW.CanCast("Kill Command") && WoW.Focus >= 30 && WoW.IsSpellInRange("Kill Command") && WoW.PetHasBuff("Beast Cleave") && WoW.PetBuffTimeRemaining("Beast Cleave") >= 1 && !(DetectKeyPress.GetKeyState(0x5A) < 0) && !FourTarget  && !(WoW.SpellCooldownTimeRemaining("Bestial Wrath") <= 2))
                    {
                        WoW.CastSpell("Kill Command");
                        return;
                    }
					if (WoW.CanCast("Kill Command") && WoW.Focus >= 30 && !FourTarget && WoW.IsSpellInRange("Kill Command") && WoW.PetHasBuff("Beast Cleave") && WoW.PetBuffTimeRemaining("Beast Cleave") >= 1 && (WoW.PlayerHasBuff("Aspect of the Wild") || WoW.PlayerHasBuff("Bloodlust") || WoW.PlayerHasBuff("Ancient Hysteria") || WoW.PlayerHasBuff("Drums") || WoW.PlayerHasBuff("Netherwinds")))
                    {
                        WoW.CastSpell("Kill Command");
                        return;
                    }
                    if (WoW.CanCast("Cobra Shot") && (WoW.Focus >= 40) && WoW.IsSpellInRange("Cobra Shot") && WoW.PetHasBuff("Beast Cleave") && WoW.PetBuffTimeRemaining("Beast Cleave") >= 2 && WoW.PlayerHasBuff("Bestial Wrath") && (WoW.SpellCooldownTimeRemaining("Kill Command") >= 3))
                    {
                        WoW.CastSpell("Cobra Shot");
                        return;
                    }
					if (WoW.CanCast("Cobra Shot") && (WoW.Focus >= 110) && WoW.IsSpellInRange("Cobra Shot") && WoW.PetHasBuff("Beast Cleave") && WoW.PetBuffTimeRemaining("Beast Cleave") >= 1 && ((WoW.SpellCooldownTimeRemaining("Bestial Wrath") >= 1) || (WoW.SpellCooldownTimeRemaining("Kill Command") >= 1) || !(WoW.PetBuffTimeRemaining("Beast Cleave") <= 2) || (WoW.SpellCooldownTimeRemaining("Dire Beast") >= 1) || (WoW.SpellCooldownTimeRemaining("A Murder of Crows") >= 1)))
                    {
                        WoW.CastSpell("Cobra Shot");
                        return;
                    }
				}
            }
            if (combatRoutine.Type == RotationType.SingleTargetCleave)
			{
				
                    if (WoW.CanCast("Death") && WoW.HealthPercent < 40 && Death && !WoW.IsSpellOnCooldown("Death") && WoW.HealthPercent != 0)
                    {
                        WoW.CastSpell("Death");
                        return;
                    }
                    if (WoW.CanCast("Exhil") && WoW.HealthPercent < 30 && Exhil && !WoW.IsSpellOnCooldown("Exhil") && WoW.HealthPercent != 0)
                    {
                        WoW.CastSpell("Exhil");
                        return;
                    }	
					if (WoW.CanCast("Turtle") && WoW.HealthPercent < 20 && Turtle && !WoW.IsSpellOnCooldown("Turtle") && WoW.HealthPercent != 0)
                    {
                        WoW.CastSpell("Turtle");
                        return;
                    }
					if (WoW.CanCast("Ancient Healing Potion") && WoW.HealthPercent < 20 && !WoW.IsSpellOnCooldown("Ancient Healing Potion") && WoW.HealthPercent != 0)
						{
							WoW.CastSpell("Ancient Healing Potion");
							return;
						}
					/*if (WoW.CanCast("Silkweave Bandage") && WoW.HealthPercent < 40 && WoW.PlayerHasBuff("Turtle") && !WoW.IsMoving && !WoW.PlayerHasDebuff("Bandaged"))
						{
							WoW.CastSpell("Silkweave Bandage");
							return;
						}*/
					
                if (WoW.HasTarget && WoW.TargetIsEnemy && WoW.IsInCombat)
                {
                    if (!WoW.HasPet && WoW.CanCast("Wolf"))
					{
						WoW.CastSpell("Wolf") ;
						return;
					}
					if (WoW.PetHealthPercent <= 0 && WoW.CanCast("Phoenix"))
					{
						WoW.CastSpell("Phoenix") ;
						return;
					}					
					if (WoW.PetHealthPercent <= 0 && WoW.IsSpellOnCooldown("Phoenix") && WoW.CanCast("Revive Pet") && !WoW.IsMoving)
					{
						WoW.CastSpell("Revive Pet") ;
						return;
					}
					if (WoW.HasTarget && WoW.TargetIsEnemy && WoW.IsInCombat && multishotwatch.ElapsedMilliseconds == 0)
                    {
						multishotwatch.Start ();
						Log.WritePixelMagic("multishotwatch started..", Color.Black);	
						return;
					}
										
					/*if (WoW.CanCast("Ring") && !WoW.IsSpellOnCooldown("Ring") && !WoW.PlayerHasDebuff("Temptation"))
                    {
						WoW.CastSpell("Ring");
						return;
					}*/			
                    if (WoW.TargetIsCasting && CounterShot && interruptwatch.ElapsedMilliseconds == 0)
                    {
						interruptwatch.Start ();
						Log.WritePixelMagic("interruptwatch started..", Color.Black);	
						return;
					}															
                       if ((multishotwatch.ElapsedMilliseconds > 3000) && !WoW.IsSpellOnCooldown("Multi-Shot") && !WoW.WasLastCasted("Multi-Shot") && WoW.Focus >= 40)
                        {
                            WoW.CastSpell("Multi-Shot");
                            multishotwatch.Reset();
                            multishotwatch.Start();
                            return;
                        }	
                    if (WoW.TargetIsCasting && CounterShot && interruptwatch.ElapsedMilliseconds > 800)
                    {
                        if (WoW.CanCast("Counter Shot") && !WoW.IsSpellOnCooldown("Counter Shot") && CounterShot && !WoW.PlayerIsChanneling && !WoW.WasLastCasted("Counter Shot"))
                        {
                            WoW.CastSpell("Counter Shot");
                            interruptwatch.Reset();
							Log.WritePixelMagic("interruptwatch reset!", Color.Black);							
                            interruptwatch.Start();
							Log.WritePixelMagic("interruptwatch started...", Color.Black);							
                            return;
                        }	
					}						
                    if (WoW.CanCast("A Murder of Crows") && !WoW.IsSpellOnCooldown("A Murder of Crows") && Crow && WoW.IsSpellInRange("A Murder of Crows") && WoW.Focus >= 30  && !(WoW.SpellCooldownTimeRemaining("Bestial Wrath") <= 2))
                    {
                        WoW.CastSpell("A Murder of Crows");
                        return;
                    }
                    if (WoW.CanCast("Barrage") && Barrage && WoW.IsSpellInRange("Barrage") && WoW.Focus >= 60)
                    {
                        WoW.CastSpell("Barrage");
                        return;
                    }					
					if (WoW.CanCast("Bestial Wrath") && !WoW.IsSpellOnCooldown("Bestial Wrath") && !(WoW.SpellCooldownTimeRemaining("Kill Command") >= 3))
                    {
                        WoW.CastSpell("Bestial Wrath");
                        return;
                    }
					if (WoW.CanCast("Aspect of the Wild") && !WoW.IsSpellOnCooldown("Aspect of the Wild")  && WoW.PlayerHasBuff("Bestial Wrath") && (dpscooldowns || WoW.PlayerHasBuff("Bloodlust") || WoW.PlayerHasBuff("Ancient Hysteria") || WoW.PlayerHasBuff("Netherwinds") || WoW.PlayerHasBuff("Drums") || WoW.PlayerHasBuff("Heroism") || WoW.PlayerHasBuff("Time Warp") )) 
                    {
                        WoW.CastSpell("Aspect of the Wild");
						WoW.CastSpell("Blood Fury");
						return;
                    }	
					if (WoW.CanCast("Potion Power") && !WoW.IsSpellOnCooldown("Potion Power") && !WoW.PlayerHasBuff("Potion Power") && (WoW.PlayerHasBuff("Bloodlust") || WoW.PlayerHasBuff("Ancient Hysteria") || WoW.PlayerHasBuff("Netherwinds") || WoW.PlayerHasBuff("Drums") || WoW.PlayerHasBuff("Heroism") || WoW.PlayerHasBuff("Time Warp")))
					{
						WoW.CastSpell("Potion Power");
						return;
					}				
                    if (WoW.CanCast("Dire Beast") && WoW.IsSpellInRange("Dire Beast") && !WoW.IsSpellOnCooldown("Dire Beast") && !(WoW.SpellCooldownTimeRemaining("Bestial Wrath") <= 2))
                    {
                        WoW.CastSpell("Dire Beast");
						if (WoW.CanCast("Titan's Thunder") && !WoW.IsSpellOnCooldown("Titan's Thunder"))
						{
                        WoW.CastSpell("Titan's Thunder");
                        return;
						}
                    }
                    if (WoW.CanCast("Kill Command") && WoW.Focus >= 30 && WoW.IsSpellInRange("Kill Command") && !(WoW.SpellCooldownTimeRemaining("Bestial Wrath") <= 2))
                    {
                        WoW.CastSpell("Kill Command");
                        return;
                    }						
                    if (WoW.CanCast("Multi-Shot") && (WoW.Focus >= 40) && WoW.IsSpellInRange("Multi-Shot") && WoW.PlayerHasBuff("Bestial Wrath") && (WoW.SpellCooldownTimeRemaining("Kill Command") >= 3))
{
                            WoW.CastSpell("Multi-Shot");
                            multishotwatch.Reset();
                            multishotwatch.Start();
                            return;
                        }
                    if (WoW.Focus >= 90 && WoW.CanCast("Multi-Shot") && WoW.IsSpellInRange("Multi-Shot")) //  && (WoW.PetBuffTimeRemaining("Beast Cleave") <= 2) && !WoW.WasLastCasted("Cobra Shot")
                        {
                            WoW.CastSpell("Multi-Shot");
                            multishotwatch.Reset();
                            multishotwatch.Start();
                            return;
                        }
					if (WoW.CanCast("Concussive") && WoW.IsSpellInRange("Concussive"))
                    {
                        WoW.CastSpell("Concussive");
                        return;
                    }	
                }
            }
        }

        public override string Name
        {
            get { return "HunterBeastmastery"; }
        }

        public override string Class
        {
            get { return "Hunter"; }
        }

        private static Image TopLogo
        {
            get
            {
                var newByteArray = "71,73,70,56,57,97,217,1,119,0,247,0,0,0,0,0,0,0,51,0,0,102,0,0,153,0,0,204,0,0,255,0,43,0,0,43,51,0,43,102,0,43,153,0,43,204,0,43,255,0,85,0,0,85,51,0,85,102,0,85,153,0,85,204,0,85,255,0,128,0,0,128,51,0,128,102,0,128,153,0,128,204,0,128,255,0,170,0,0,170,51,0,170,102,0,170,153,0,170,204,0,170,255,0,213,0,0,213,51,0,213,102,0,213,153,0,213,204,0,213,255,0,255,0,0,255,51,0,255,102,0,255,153,0,255,204,0,255,255,51,0,0,51,0,51,51,0,102,51,0,153,51,0,204,51,0,255,51,43,0,51,43,51,51,43,102,51,43,153,51,43,204,51,43,255,51,85,0,51,85,51,51,85,102,51,85,153,51,85,204,51,85,255,51,128,0,51,128,51,51,128,102,51,128,153,51,128,204,51,128,255,51,170,0,51,170,51,51,170,102,51,170,153,51,170,204,51,170,255,51,213,0,51,213,51,51,213,102,51,213,153,51,213,204,51,213,255,51,255,0,51,255,51,51,255,102,51,255,153,51,255,204,51,255,255,102,0,0,102,0,51,102,0,102,102,0,153,102,0,204,102,0,255,102,43,0,102,43,51,102,43,102,102,43,153,102,43,204,102,43,255,102,85,0,102,85,51,102,85,102,102,85,153,102,85,204,102,85,255,102,128,0,102,128,51,102,128,102,102,128,153,102,128,204,102,128,255,102,170,0,102,170,51,102,170,102,102,170,153,102,170,204,102,170,255,102,213,0,102,213,51,102,213,102,102,213,153,102,213,204,102,213,255,102,255,0,102,255,51,102,255,102,102,255,153,102,255,204,102,255,255,153,0,0,153,0,51,153,0,102,153,0,153,153,0,204,153,0,255,153,43,0,153,43,51,153,43,102,153,43,153,153,43,204,153,43,255,153,85,0,153,85,51,153,85,102,153,85,153,153,85,204,153,85,255,153,128,0,153,128,51,153,128,102,153,128,153,153,128,204,153,128,255,153,170,0,153,170,51,153,170,102,153,170,153,153,170,204,153,170,255,153,213,0,153,213,51,153,213,102,153,213,153,153,213,204,153,213,255,153,255,0,153,255,51,153,255,102,153,255,153,153,255,204,153,255,255,204,0,0,204,0,51,204,0,102,204,0,153,204,0,204,204,0,255,204,43,0,204,43,51,204,43,102,204,43,153,204,43,204,204,43,255,204,85,0,204,85,51,204,85,102,204,85,153,204,85,204,204,85,255,204,128,0,204,128,51,204,128,102,204,128,153,204,128,204,204,128,255,204,170,0,204,170,51,204,170,102,204,170,153,204,170,204,204,170,255,204,213,0,204,213,51,204,213,102,204,213,153,204,213,204,204,213,255,204,255,0,204,255,51,204,255,102,204,255,153,204,255,204,204,255,255,255,0,0,255,0,51,255,0,102,255,0,153,255,0,204,255,0,255,255,43,0,255,43,51,255,43,102,255,43,153,255,43,204,255,43,255,255,85,0,255,85,51,255,85,102,255,85,153,255,85,204,255,85,255,255,128,0,255,128,51,255,128,102,255,128,153,255,128,204,255,128,255,255,170,0,255,170,51,255,170,102,255,170,153,255,170,204,255,170,255,255,213,0,255,213,51,255,213,102,255,213,153,255,213,204,255,213,255,255,255,0,255,255,51,255,255,102,255,255,153,255,255,204,255,255,255,0,0,0,0,0,0,0,0,0,0,0,0,33,249,4,1,0,0,252,0,44,0,0,0,0,217,1,119,0,0,8,255,0,99,192,128,1,32,12,38,0,48,84,24,80,65,16,70,152,27,97,108,132,57,3,38,12,12,27,146,192,0,0,115,49,204,37,48,103,46,194,184,97,99,160,72,147,19,207,132,65,163,114,98,24,151,38,77,114,188,168,101,32,199,138,96,34,9,187,20,233,82,152,72,145,206,0,253,9,244,146,176,96,200,132,193,0,131,179,98,80,149,103,36,97,18,122,38,106,208,72,152,36,93,157,136,41,168,164,159,93,83,70,146,36,20,77,36,177,66,37,93,234,170,149,108,80,179,6,133,157,81,97,241,6,199,48,55,241,234,141,90,21,171,86,179,85,181,158,17,118,84,237,216,180,86,15,107,205,58,22,40,166,174,135,35,153,213,218,152,242,226,75,151,119,82,22,198,150,170,91,196,141,43,3,181,202,183,50,226,69,66,177,18,230,220,56,173,99,213,162,33,175,134,156,213,40,97,204,152,131,97,90,45,44,233,174,221,152,130,105,53,170,86,173,48,227,199,109,239,54,186,123,39,103,194,73,121,75,95,45,47,153,188,222,216,147,106,207,142,125,117,244,237,211,9,87,255,151,23,221,122,178,238,209,121,35,3,47,108,30,249,240,194,172,207,67,246,158,48,194,130,151,98,34,52,224,16,47,196,159,22,245,39,81,72,78,85,20,160,73,37,13,148,96,76,6,254,231,144,67,187,236,34,201,46,139,68,178,200,133,254,105,97,195,22,28,233,68,25,24,194,0,117,21,38,60,5,35,158,48,6,226,244,147,24,65,45,210,85,84,97,8,246,21,102,103,152,53,217,85,81,77,69,22,89,46,145,117,6,35,146,69,194,226,99,135,149,102,80,90,96,168,112,151,22,55,48,169,133,94,6,158,133,134,139,61,185,245,147,89,170,17,166,152,85,59,210,200,24,95,82,241,114,137,85,88,186,129,21,86,92,70,213,150,36,194,53,134,6,100,99,253,244,35,105,65,90,53,149,144,135,45,210,165,91,82,121,101,25,137,50,42,214,152,110,103,178,133,21,115,99,225,38,9,118,58,193,214,220,163,151,136,89,92,114,188,96,37,233,114,188,96,215,231,115,187,233,230,221,87,193,1,183,221,118,215,245,54,31,116,208,177,243,29,170,241,161,58,106,111,214,181,255,218,91,117,222,185,74,152,24,234,9,243,204,117,233,121,226,221,169,231,173,6,195,22,54,96,146,208,25,2,13,164,130,68,17,189,4,198,13,29,25,11,131,74,203,130,97,3,69,15,197,52,80,12,27,150,84,17,69,195,130,177,72,66,48,104,33,238,22,97,40,242,210,34,0,134,129,33,187,223,134,8,73,70,61,97,229,105,81,71,177,115,137,13,76,225,117,86,89,42,61,22,99,96,85,169,249,84,140,151,152,37,134,80,152,76,132,26,89,44,206,89,214,83,172,217,248,240,138,63,93,82,144,68,77,150,43,145,185,123,73,198,176,155,92,170,166,27,102,145,161,65,227,142,135,182,245,26,159,37,51,22,164,78,40,179,54,51,97,148,217,120,213,100,174,129,134,37,96,99,253,229,215,68,141,33,218,86,98,103,114,246,91,91,199,101,137,50,38,149,70,135,89,136,82,153,200,155,113,139,134,24,156,36,125,50,70,156,109,71,65,109,155,167,132,97,130,134,24,19,61,55,93,82,242,12,3,30,175,110,19,150,204,122,185,114,55,221,110,213,169,138,221,121,116,179,255,42,119,24,98,160,33,149,120,115,251,189,27,50,243,209,215,221,69,201,226,165,2,0,252,197,240,172,68,252,254,7,165,13,26,218,196,145,68,219,242,167,237,72,49,40,4,0,0,139,236,162,130,228,238,94,168,110,233,21,178,123,161,133,21,85,104,145,220,243,136,27,34,161,154,113,7,111,148,68,115,181,243,86,64,185,241,82,85,68,66,37,149,74,159,233,28,35,159,103,122,198,87,105,187,45,229,80,69,255,197,126,214,138,94,117,134,218,84,12,135,120,220,25,93,1,38,216,89,197,45,198,112,86,81,181,97,126,113,40,7,73,228,88,156,29,221,52,89,23,215,233,166,104,59,254,136,167,161,148,5,29,149,210,157,145,209,110,116,210,21,200,24,70,39,201,89,204,88,146,82,64,248,169,70,57,145,234,74,205,20,120,155,178,69,10,59,152,248,77,217,50,181,19,180,137,1,34,234,57,92,111,226,150,30,100,240,205,86,165,66,6,38,144,49,12,195,37,197,87,229,233,27,50,218,129,184,86,177,176,108,217,121,137,24,112,176,40,197,205,6,61,243,16,70,219,255,120,3,45,139,68,68,32,8,97,136,179,94,2,131,72,216,0,25,78,180,1,231,236,82,68,149,92,4,33,49,17,136,69,30,199,144,45,48,4,6,11,217,66,233,128,194,139,114,133,97,11,202,18,215,34,158,244,186,53,186,75,39,76,49,145,36,20,17,137,124,88,200,68,73,9,6,182,114,242,145,175,192,232,120,3,243,163,89,94,196,136,51,184,200,101,224,11,210,155,80,35,167,130,145,5,13,68,123,216,196,2,227,17,97,208,101,41,47,49,87,236,82,67,180,201,24,176,52,109,201,10,99,220,50,25,158,141,37,124,149,105,154,160,132,22,190,246,161,143,51,193,104,223,90,90,67,202,179,8,42,77,87,25,95,162,248,228,163,162,180,16,51,71,147,4,187,154,118,27,94,24,176,45,196,105,20,114,132,241,155,223,128,109,53,114,52,138,164,146,230,192,172,117,165,55,80,123,140,167,152,227,193,45,16,16,150,34,60,81,16,73,101,183,17,166,135,85,39,12,143,124,178,51,206,18,162,199,109,140,128,136,24,196,48,143,116,70,231,112,227,89,143,10,133,209,255,172,129,28,40,89,36,193,139,68,132,97,134,160,240,68,65,26,218,28,38,27,178,159,129,88,200,34,236,186,207,232,74,23,140,210,241,130,66,236,82,18,26,99,224,46,35,174,235,93,235,178,151,80,146,146,22,19,93,199,95,57,249,23,75,136,183,149,130,61,204,71,80,121,145,91,128,151,63,157,125,166,56,58,131,11,139,32,73,162,130,224,68,114,18,233,215,88,20,193,39,148,49,207,45,180,25,77,160,152,39,202,200,188,104,102,9,227,201,46,157,26,34,213,244,41,71,180,44,13,139,232,71,63,67,237,212,43,88,13,37,249,26,22,137,232,20,7,40,72,245,158,216,144,41,38,11,78,170,172,101,179,212,55,141,130,12,173,60,103,170,108,249,154,247,22,117,30,226,224,240,18,99,64,219,13,178,166,182,92,21,14,60,136,45,103,111,190,227,206,125,18,174,59,137,163,97,119,10,27,157,72,200,83,18,38,228,205,10,161,51,143,249,4,113,53,208,138,201,13,20,242,197,48,104,232,33,214,90,10,38,238,226,16,27,168,160,136,204,194,162,1,208,165,133,24,255,212,228,113,250,49,64,45,44,114,209,72,212,2,118,107,132,129,109,181,176,8,3,105,129,67,23,10,174,184,86,103,161,69,241,196,56,199,72,10,78,26,3,32,67,242,5,53,44,201,95,34,99,4,22,193,20,178,43,11,83,25,143,96,228,21,162,245,9,48,168,121,203,89,118,114,73,189,244,199,64,21,34,88,162,58,19,36,80,81,205,168,115,66,165,157,240,39,211,153,113,109,170,69,27,165,137,66,99,192,230,210,9,104,94,65,153,33,237,135,213,180,88,6,40,191,60,78,133,6,233,34,239,177,38,175,139,201,84,6,11,136,217,178,73,104,45,224,44,27,155,196,198,22,173,125,211,170,70,185,142,115,25,17,42,70,124,16,109,156,10,155,218,240,86,195,20,14,35,133,222,137,155,175,226,38,12,118,164,179,57,216,156,15,175,76,197,30,119,22,142,159,47,182,230,224,120,83,207,247,68,39,73,194,53,9,22,1,80,197,136,96,50,34,148,155,150,181,84,148,90,110,149,206,180,139,24,157,152,79,7,0,21,8,99,29,108,164,144,184,192,176,133,227,178,153,255,141,166,229,16,186,22,129,185,24,136,209,117,53,97,215,89,26,214,28,121,124,164,34,144,8,74,74,88,98,144,183,196,151,187,82,73,137,239,160,167,18,176,22,169,70,96,117,46,90,7,54,37,190,68,175,36,120,145,156,134,56,148,49,239,38,114,169,99,58,101,163,196,231,51,199,156,55,40,3,84,139,41,11,181,37,85,14,16,188,103,202,159,100,30,6,148,82,234,201,52,92,5,75,101,120,50,200,5,198,149,171,65,209,18,0,37,212,40,154,105,73,45,81,211,18,91,116,35,199,213,168,6,106,133,98,211,224,44,101,20,157,228,49,43,243,92,148,60,13,18,29,79,117,170,59,177,98,225,170,220,201,99,86,121,162,200,133,13,55,237,208,83,43,191,73,226,6,30,172,107,224,126,184,158,83,205,70,32,252,193,162,178,30,196,172,254,68,100,38,253,246,143,20,141,24,140,48,104,52,18,187,96,232,233,6,114,161,45,132,238,62,1,40,115,196,71,183,2,3,172,128,92,196,197,75,198,203,181,220,97,165,171,184,21,74,84,48,242,145,145,48,152,1,64,96,255,160,95,192,200,170,18,192,176,116,37,103,193,239,153,32,73,166,160,0,233,74,182,108,26,96,32,249,22,138,200,133,46,79,2,131,228,166,167,23,25,217,9,101,226,35,139,114,44,51,177,155,158,181,50,253,77,141,217,98,221,190,179,74,197,168,162,153,36,41,105,29,21,26,205,12,148,79,69,95,100,112,104,168,168,184,136,39,56,195,141,168,181,70,36,73,229,17,217,83,235,84,115,34,85,237,18,159,137,128,26,28,28,3,9,3,201,52,136,33,6,104,11,195,61,103,92,216,16,217,115,178,171,66,60,97,124,76,24,95,117,103,55,238,57,114,13,209,192,110,32,167,19,112,55,224,194,217,196,176,168,205,202,77,30,167,66,134,137,26,98,18,133,224,91,91,252,162,9,166,47,194,17,136,96,242,12,38,90,4,67,16,178,91,47,150,121,32,104,20,221,232,98,192,251,24,224,192,247,49,184,129,12,122,63,241,209,169,64,5,28,58,110,113,229,92,91,119,177,121,152,214,142,68,236,64,162,104,66,115,102,34,17,227,46,154,168,242,166,72,171,92,104,144,14,127,255,96,170,74,63,145,93,137,74,34,209,75,80,245,82,148,155,42,216,125,104,117,78,164,79,211,107,253,194,38,193,55,242,139,160,10,184,136,100,10,102,126,179,70,94,63,51,20,252,51,49,9,182,38,150,241,92,30,38,52,72,197,11,131,209,64,10,100,41,3,230,23,86,3,129,96,115,56,215,148,106,138,146,129,15,100,97,21,36,9,47,6,56,128,115,78,23,24,87,240,86,31,208,209,66,238,244,120,232,113,78,179,161,29,246,52,31,47,65,121,231,228,43,56,38,130,240,22,6,60,180,26,116,21,121,165,18,61,82,230,57,89,36,90,169,53,18,174,133,101,47,33,17,151,16,12,21,101,90,97,192,14,187,240,113,11,113,0,100,6,0,189,7,120,56,176,67,243,36,3,97,192,5,243,164,131,127,23,3,7,176,2,98,86,102,0,160,5,196,229,102,103,184,8,138,128,70,110,102,109,76,1,18,57,241,45,214,213,117,68,3,35,132,22,22,244,99,84,157,214,23,22,51,49,11,243,21,88,33,83,217,21,20,17,211,21,28,133,73,77,34,116,21,161,46,58,255,49,17,146,96,74,51,37,24,143,18,107,134,100,74,93,215,39,46,67,36,58,114,119,92,163,118,148,97,64,154,129,86,107,49,83,164,22,39,181,38,26,228,163,72,170,168,96,105,197,25,101,135,76,145,64,40,134,225,50,176,168,25,207,117,79,202,68,54,206,182,97,109,114,28,191,8,109,202,134,65,241,35,6,232,178,109,52,20,42,127,149,20,104,176,5,55,96,43,237,230,88,107,179,26,233,36,12,142,247,121,140,103,42,156,193,81,148,119,139,208,17,44,13,115,6,198,24,6,128,247,40,222,97,30,221,33,132,228,18,3,11,145,69,9,18,17,53,49,16,161,149,122,176,183,11,145,192,14,77,104,33,201,181,70,86,56,44,188,135,3,43,16,56,243,20,56,147,128,3,97,144,6,155,55,144,31,228,140,49,176,2,188,103,113,250,38,103,96,224,102,229,194,16,195,244,18,120,129,26,78,81,35,190,131,125,84,49,86,4,147,72,140,182,8,44,49,127,56,82,72,210,38,36,45,33,142,229,245,17,116,129,19,196,162,23,47,81,80,142,102,137,82,17,118,97,255,83,36,48,51,62,154,248,52,193,224,21,169,168,116,159,36,106,155,17,34,128,1,128,127,56,62,102,241,48,168,116,83,9,150,61,64,25,108,0,100,115,64,233,50,200,116,86,106,101,28,88,161,42,93,33,41,194,97,34,205,1,63,181,81,28,13,244,106,119,133,29,204,38,12,104,192,81,243,132,44,233,177,28,132,33,130,34,40,68,138,55,29,48,244,28,226,182,66,122,83,120,208,225,100,114,67,24,91,240,119,95,17,6,57,118,79,128,7,73,16,209,121,56,84,67,224,97,44,2,81,113,164,55,16,11,33,132,152,67,18,243,136,105,6,176,8,194,176,8,193,32,15,38,18,12,187,96,46,197,197,81,49,0,57,12,201,123,0,112,0,98,144,9,147,192,154,153,16,6,99,128,6,147,144,6,146,224,119,9,249,119,16,17,3,23,2,3,17,167,2,104,232,134,199,133,123,48,64,5,96,160,8,40,2,104,122,1,73,61,34,60,96,5,115,106,130,61,66,3,22,44,65,107,226,131,125,130,166,127,169,1,24,11,99,75,242,200,36,22,33,57,156,230,20,79,255,117,35,161,168,127,29,150,117,100,241,84,87,121,119,68,18,129,155,8,51,175,241,64,157,113,108,45,82,26,130,67,107,49,34,34,124,50,97,141,193,34,254,3,117,34,166,24,168,81,85,128,242,92,69,35,108,196,4,87,191,17,109,223,198,25,185,1,109,141,114,28,26,148,129,158,98,86,207,241,119,43,17,79,139,240,154,193,193,41,104,3,120,15,81,29,137,247,42,127,57,89,132,17,55,230,104,141,114,147,20,193,178,29,255,113,152,137,39,6,13,195,93,92,136,43,21,164,30,227,36,44,146,169,45,2,145,44,88,196,45,254,132,122,179,200,153,20,69,33,103,84,91,42,112,0,165,73,133,55,192,123,14,81,102,153,48,12,174,57,9,50,58,9,147,80,155,145,216,8,2,57,79,46,38,6,187,192,8,78,58,113,229,210,102,195,89,46,181,229,102,32,99,72,215,242,47,29,73,115,46,17,48,79,209,51,59,130,9,216,85,39,224,103,126,36,226,38,220,5,38,131,225,94,120,17,158,122,81,33,59,34,148,104,82,62,94,113,29,239,103,72,57,147,96,243,255,131,25,3,84,95,77,135,158,68,18,23,112,50,136,104,245,145,68,1,105,59,9,32,62,98,116,7,120,74,66,113,27,79,215,24,163,180,107,177,230,160,23,22,34,55,20,41,88,177,160,120,9,20,83,201,62,88,35,28,133,65,87,60,88,54,228,184,48,58,72,142,207,97,53,32,184,109,229,150,130,63,36,29,34,164,29,35,90,129,67,86,30,132,1,120,47,6,28,168,194,172,240,230,65,206,90,65,53,244,120,193,0,70,202,98,133,147,105,18,158,19,57,220,250,163,246,184,11,151,208,58,21,165,8,197,181,2,74,138,16,165,9,0,14,217,123,169,57,12,196,48,12,173,57,79,86,42,9,147,32,155,129,131,6,140,128,6,9,25,6,140,176,11,189,71,16,198,23,156,229,98,91,228,226,113,76,33,125,195,3,32,143,1,21,214,169,18,152,177,34,225,247,47,47,130,26,17,91,39,3,147,94,98,215,75,14,43,120,1,82,19,17,65,44,225,153,157,185,100,40,145,225,6,253,87,171,66,163,51,177,193,97,179,8,40,137,82,50,145,225,22,75,35,20,114,255,52,107,169,102,93,53,101,75,112,65,167,172,232,148,141,65,37,85,201,26,188,192,74,134,84,109,110,213,24,33,226,87,193,200,40,79,163,65,99,99,87,13,116,28,247,149,170,91,51,31,219,196,119,206,56,79,105,128,46,29,10,151,144,20,120,116,153,88,219,177,89,131,39,29,103,171,54,136,115,78,167,18,3,144,20,3,132,69,68,128,19,120,131,69,24,96,137,67,213,104,31,81,166,142,4,161,16,23,247,69,164,245,163,48,48,174,187,0,154,230,10,114,139,80,154,168,201,174,6,192,81,234,250,56,86,56,15,82,218,154,43,113,175,247,202,8,180,57,6,181,57,144,58,232,123,81,120,133,102,136,16,199,133,134,195,98,166,104,248,36,120,81,21,43,209,166,36,249,20,160,2,21,66,145,48,3,131,21,43,161,38,0,67,146,183,251,73,100,81,72,120,162,18,194,128,105,65,133,58,42,18,114,187,59,50,250,119,169,29,102,148,172,136,38,168,70,117,146,145,179,173,241,169,2,212,21,122,194,26,255,103,147,214,117,107,124,34,39,181,38,168,115,210,60,139,255,33,136,72,165,64,15,54,24,88,51,85,69,233,23,17,116,143,73,145,40,146,130,67,23,102,143,41,57,65,22,22,65,120,4,191,187,241,161,99,240,16,28,197,52,187,241,21,129,19,3,38,58,89,64,102,162,43,232,29,5,108,29,136,149,12,150,181,175,132,201,41,89,97,68,98,208,181,55,192,8,123,7,78,38,146,78,190,98,44,10,49,16,83,182,163,96,84,154,96,212,193,234,106,33,20,226,91,192,149,184,0,32,3,31,116,113,98,150,9,98,0,57,86,8,17,147,160,9,81,58,9,128,199,154,246,42,155,250,122,54,32,200,185,49,80,11,184,25,176,7,176,123,191,201,113,167,83,19,128,90,105,200,19,142,144,200,146,182,203,35,144,209,196,67,65,48,117,218,59,12,3,126,0,195,23,252,244,32,18,9,37,195,227,104,161,146,24,110,96,25,186,248,189,3,200,8,113,23,52,142,97,178,6,3,170,145,113,169,131,209,38,22,210,158,56,194,138,63,209,169,136,52,83,174,129,84,74,21,127,217,36,40,21,214,19,9,68,170,207,54,139,90,249,118,138,255,146,181,222,163,190,25,118,38,136,2,28,58,17,44,198,86,24,57,24,120,28,101,57,132,129,3,140,144,9,131,69,30,12,148,120,139,73,140,216,52,89,96,227,41,121,115,30,155,53,15,47,241,154,54,138,145,15,145,171,152,103,163,240,139,67,228,193,99,163,183,16,161,195,31,128,75,46,36,76,90,242,88,92,187,48,145,230,90,156,17,21,0,191,55,88,195,192,53,140,0,56,201,96,140,165,73,12,250,96,103,172,41,6,7,160,195,105,112,165,180,153,6,46,134,131,14,7,183,181,208,123,16,105,133,196,245,56,96,80,8,99,122,186,99,58,32,46,225,17,215,3,187,14,243,34,195,131,62,72,37,142,169,225,176,134,40,50,46,34,83,151,232,48,215,131,12,22,1,178,169,117,70,235,23,25,91,149,87,174,193,18,115,151,50,81,153,22,179,116,64,143,154,137,145,134,86,45,242,62,4,52,179,174,152,177,90,151,94,119,90,188,154,200,198,125,188,116,112,18,170,215,116,95,195,97,87,60,97,76,240,115,9,140,167,76,89,130,77,142,177,160,236,163,53,198,255,244,27,180,26,28,125,211,28,97,11,56,252,74,142,228,200,123,55,64,64,11,51,12,127,23,30,251,84,192,156,145,9,205,113,78,152,144,9,63,180,212,116,147,66,152,0,183,48,76,121,136,200,123,206,200,211,95,24,56,29,138,170,124,165,89,156,209,142,37,97,122,219,122,0,35,124,31,81,6,3,236,82,11,107,228,134,226,242,56,255,24,6,147,48,12,195,64,15,118,173,15,244,176,15,195,16,6,8,33,205,244,208,14,48,28,173,178,89,205,61,60,144,6,185,67,188,231,58,232,82,113,0,32,70,91,240,184,230,170,5,132,48,145,100,138,134,114,50,60,146,32,60,198,115,217,152,129,94,79,21,35,47,98,207,197,235,166,134,232,168,15,3,52,37,41,120,53,97,23,24,25,116,25,231,20,159,113,40,247,147,26,35,102,26,120,82,28,8,211,121,230,169,27,71,83,95,166,134,24,223,67,22,90,226,84,20,77,21,228,53,187,67,18,180,88,178,96,50,51,136,219,131,86,243,96,20,88,39,220,22,102,117,119,151,28,3,164,54,194,145,27,200,177,116,120,255,215,21,75,179,221,214,171,27,191,241,89,213,230,65,43,129,54,14,231,211,130,211,150,199,33,163,175,73,152,36,229,121,101,83,161,74,173,212,33,244,6,74,29,78,156,17,121,90,19,151,171,201,103,199,177,18,103,195,191,28,53,131,24,201,34,195,250,30,5,204,16,72,116,176,186,156,16,186,140,214,14,81,33,138,96,46,109,104,174,42,16,0,7,112,3,156,44,9,116,77,215,196,160,12,196,64,15,250,16,195,0,32,6,251,160,12,195,192,226,87,154,9,146,0,212,98,64,165,155,151,155,31,234,65,51,108,103,23,114,92,0,160,8,181,0,185,79,50,186,190,204,33,186,10,167,45,55,104,228,35,20,171,203,22,37,57,163,142,86,21,117,202,115,134,113,135,188,251,18,194,237,79,168,139,19,172,141,19,129,194,22,240,153,93,176,248,59,35,67,219,85,23,187,6,244,92,174,81,96,89,156,115,192,132,86,92,211,104,127,88,159,75,245,145,178,102,178,129,50,72,237,107,149,193,86,64,48,203,22,246,24,28,8,100,87,214,134,139,82,75,200,4,74,53,238,255,59,65,222,102,76,179,114,43,30,84,224,55,128,174,228,120,89,92,51,37,144,4,226,239,70,152,152,224,77,181,172,54,107,121,3,180,201,64,181,25,124,115,7,75,241,129,12,236,240,110,113,25,3,152,64,212,112,187,18,92,243,171,235,29,0,153,188,175,104,195,67,182,97,20,193,82,223,152,96,0,249,38,101,164,7,45,251,241,69,21,30,9,53,49,186,108,230,143,49,192,133,246,202,11,34,62,12,243,160,12,244,48,12,144,59,9,251,144,12,241,154,9,172,105,165,84,218,163,209,58,144,193,199,133,47,209,123,23,23,196,187,240,227,48,240,13,133,160,194,5,177,70,164,139,70,54,1,56,112,234,48,86,145,18,137,70,177,87,241,50,230,101,60,42,177,48,45,167,72,62,114,37,170,11,208,195,194,44,140,104,17,107,182,239,176,65,26,42,135,64,154,97,116,189,29,190,137,36,150,191,227,148,3,184,40,214,37,127,182,52,148,220,251,85,58,59,115,65,66,20,162,102,22,23,251,95,14,63,75,147,145,178,179,72,76,161,104,87,201,225,28,230,24,9,98,255,98,47,34,36,27,246,146,97,184,65,76,72,107,86,16,241,38,95,17,124,20,55,124,89,45,56,82,138,9,243,132,6,48,254,18,152,96,144,204,232,6,143,209,28,146,240,123,193,23,56,110,176,67,77,234,123,132,213,212,130,179,30,240,54,152,146,224,202,82,49,185,202,249,143,19,55,124,131,101,244,58,104,77,182,226,41,196,142,173,105,29,101,11,7,57,116,17,6,187,112,225,182,37,46,90,96,133,14,119,3,139,176,175,246,250,245,82,26,175,98,0,185,0,128,9,245,48,15,196,224,154,32,120,54,250,186,67,11,7,56,88,189,8,97,8,3,21,231,164,141,141,46,223,224,13,108,72,5,9,161,2,187,233,69,104,72,5,182,181,176,102,147,18,220,183,241,98,81,118,104,210,73,73,110,93,1,88,60,227,5,23,220,133,12,55,49,61,19,185,68,129,10,86,54,35,95,71,169,108,84,73,75,135,178,19,173,33,201,253,67,220,145,225,17,50,66,159,15,72,93,59,114,135,173,43,62,34,114,63,91,165,159,9,216,24,201,240,24,149,18,138,203,239,251,187,255,132,118,29,138,210,162,138,50,140,190,11,206,134,64,134,146,77,19,178,28,157,71,54,242,6,56,95,143,222,249,170,213,5,46,56,218,158,21,95,15,73,199,40,21,91,144,133,252,154,21,0,129,38,70,140,3,3,111,136,185,49,208,32,26,76,152,208,160,65,24,35,217,162,48,49,14,162,201,36,73,82,38,142,104,36,133,17,3,17,13,200,72,16,65,138,217,248,17,36,26,97,151,132,9,75,246,82,24,166,150,48,98,216,188,161,2,0,12,21,48,12,244,244,169,226,39,140,27,139,140,110,209,2,70,75,33,69,1,0,172,176,25,227,164,24,170,146,38,101,210,52,44,6,0,174,0,98,208,163,199,113,146,164,52,84,65,226,216,130,163,98,66,131,140,114,42,60,160,34,0,12,167,92,169,44,170,165,179,171,22,0,74,147,110,129,161,69,75,224,27,97,194,96,138,20,38,146,152,51,31,19,159,97,120,38,140,100,196,141,21,35,46,121,166,100,36,201,146,36,55,150,28,9,147,164,196,158,63,130,150,44,44,140,77,48,134,193,220,104,29,59,76,235,72,158,255,107,95,50,173,217,113,99,100,193,26,70,218,124,166,49,230,72,194,36,33,38,141,252,82,101,73,104,54,215,6,238,28,186,36,220,192,105,34,183,110,154,243,34,205,98,54,43,46,205,185,185,120,224,154,103,218,174,222,152,51,77,97,162,49,85,39,93,92,180,113,220,152,219,75,154,89,188,253,254,151,187,48,249,143,196,37,246,126,155,41,24,73,130,1,206,37,220,12,188,132,23,151,120,41,14,25,121,208,24,35,140,194,80,90,73,35,141,26,58,110,24,142,58,228,40,68,76,196,136,65,12,195,216,178,40,164,27,10,50,8,7,49,112,176,136,197,131,34,50,200,68,11,197,192,100,24,76,56,242,112,67,142,70,203,100,52,143,198,11,9,36,169,210,88,4,63,97,144,65,102,38,97,124,19,6,6,155,108,0,76,202,157,110,42,76,40,41,139,90,4,18,69,4,219,2,12,48,184,186,1,18,96,16,188,36,18,75,118,185,36,24,55,221,100,50,140,174,196,72,102,152,177,202,42,82,33,61,245,172,104,32,186,192,8,230,146,75,32,129,100,208,75,206,220,197,255,12,69,2,76,140,43,163,4,211,2,169,192,180,48,172,178,201,22,105,227,52,197,28,187,44,190,225,40,58,99,17,76,52,155,236,51,207,54,197,206,185,48,84,181,12,25,24,192,136,161,181,217,194,208,130,74,49,103,3,77,188,246,152,3,141,52,153,160,123,14,185,198,210,204,47,62,154,226,3,206,54,231,48,51,45,140,234,46,51,112,59,154,128,75,76,188,201,106,11,35,55,96,171,45,77,55,106,61,34,79,189,153,26,196,205,219,151,138,195,36,218,100,113,115,105,191,247,140,107,178,88,220,94,74,247,220,3,147,171,13,19,8,17,59,182,221,119,151,52,142,42,139,44,12,99,139,132,10,227,226,36,200,52,10,82,199,58,147,9,82,18,19,111,88,161,160,62,15,58,200,69,181,16,162,10,33,23,87,44,145,197,147,118,244,48,153,100,118,220,81,35,52,22,177,209,200,138,94,126,217,197,227,90,146,233,165,120,47,49,96,75,24,188,226,41,6,27,96,88,237,167,155,194,48,106,17,45,140,86,164,150,173,86,0,96,11,117,226,177,199,158,123,224,185,71,255,106,124,238,193,39,159,152,22,25,200,43,70,50,153,4,34,170,210,138,97,5,3,246,188,105,32,3,204,102,91,151,120,240,193,71,234,168,227,185,7,107,124,244,97,167,156,45,186,82,132,86,69,164,164,2,134,45,108,56,44,177,145,44,35,245,140,81,133,43,60,87,97,206,96,236,90,52,206,96,132,242,206,58,99,142,179,208,62,11,3,25,27,96,149,13,232,193,13,155,109,145,232,128,107,137,180,108,53,115,238,140,38,151,171,77,55,111,169,253,237,182,219,218,67,227,18,233,108,67,76,58,221,70,75,54,245,228,140,219,76,85,242,200,83,140,85,207,70,211,76,180,100,69,139,79,163,0,129,7,30,186,51,236,205,15,248,234,244,107,247,118,100,254,67,204,65,7,157,108,73,180,96,246,75,208,65,73,252,115,55,24,94,48,145,71,38,147,164,138,129,139,25,211,226,24,36,195,82,92,41,147,79,76,62,89,38,76,68,151,27,8,164,68,56,96,203,1,96,112,128,138,89,68,6,7,25,136,36,110,224,21,144,144,12,128,153,24,201,196,194,160,150,141,225,192,13,126,246,163,202,13,200,6,146,153,25,7,96,244,255,114,18,79,96,240,51,161,104,169,39,176,217,9,0,136,22,9,69,244,36,41,181,216,153,87,12,16,0,48,148,99,23,235,144,71,62,240,33,15,121,204,35,31,250,200,68,45,202,161,8,49,28,128,43,104,152,68,199,110,128,162,173,196,197,138,10,209,201,86,182,18,0,69,168,163,28,242,24,34,17,179,166,15,122,12,163,16,222,88,68,87,184,130,20,164,68,74,11,84,160,212,168,38,51,153,83,141,4,91,161,1,222,228,142,195,25,58,134,74,56,159,249,206,180,154,85,146,85,145,10,25,90,136,21,208,196,20,155,164,184,102,84,167,250,141,109,186,163,171,38,81,39,87,181,105,195,116,4,228,188,249,16,167,117,167,67,94,128,72,163,25,125,197,167,112,158,226,142,103,68,165,158,205,140,18,56,166,219,84,182,162,99,152,246,176,82,35,228,162,14,190,68,67,44,196,180,167,58,247,201,79,129,76,248,18,118,229,242,124,152,168,100,113,114,57,175,227,248,199,37,243,25,151,205,206,23,12,18,109,193,68,252,18,13,132,72,147,65,210,25,140,116,40,9,209,255,113,4,104,19,137,197,96,109,103,91,155,21,233,66,23,130,196,160,57,42,56,72,202,126,100,18,11,109,161,96,134,169,156,70,160,180,71,13,245,233,64,52,107,23,249,90,194,11,41,209,79,133,5,181,65,12,34,145,19,27,24,165,22,131,137,20,24,210,8,0,43,50,13,18,234,216,5,45,132,97,68,125,232,67,25,146,168,5,45,202,113,18,0,160,68,98,106,65,155,77,206,185,39,29,154,173,47,235,80,135,46,214,49,143,142,234,163,30,188,40,132,43,200,177,139,173,168,17,6,70,3,140,10,148,18,152,220,25,102,115,159,201,213,100,42,83,45,76,36,79,49,144,153,76,229,174,69,153,165,122,6,144,147,17,3,50,192,0,52,160,89,136,82,132,155,13,234,86,7,28,117,173,202,90,145,104,82,36,147,229,45,55,88,167,122,203,226,228,238,158,35,9,238,104,146,174,103,112,80,185,172,51,157,92,169,135,142,156,17,165,115,70,2,134,159,193,96,88,247,217,94,117,216,245,62,210,52,86,63,250,73,14,105,20,123,174,105,253,135,73,194,16,31,185,4,255,122,59,244,137,6,64,248,209,236,126,226,213,18,170,204,39,160,40,100,207,76,118,65,154,214,196,192,158,82,241,8,196,54,50,9,195,100,34,12,1,216,161,92,214,70,177,29,158,83,5,97,200,132,61,51,161,163,76,36,195,35,47,19,161,97,172,35,80,153,156,207,102,241,27,145,24,200,135,159,209,250,235,103,133,25,211,77,174,20,6,194,9,101,134,138,0,3,82,20,49,81,0,232,101,135,90,128,7,60,212,17,211,117,228,99,24,139,240,198,58,118,81,14,45,160,20,37,19,211,147,2,121,184,55,115,26,68,5,3,177,162,92,20,1,15,96,168,163,192,236,80,6,78,105,81,11,37,242,69,46,106,12,195,151,20,177,5,66,132,1,142,176,132,28,226,78,99,85,239,244,78,56,162,41,149,112,164,202,185,83,229,171,91,139,41,73,93,197,32,143,213,180,120,17,132,165,213,108,90,83,75,82,85,182,121,99,101,73,246,196,67,74,106,221,206,118,62,150,142,241,142,35,187,202,113,178,54,196,251,72,249,108,147,188,186,6,57,118,252,156,137,114,195,32,19,255,76,128,97,88,139,0,87,190,116,204,156,116,153,214,65,208,105,15,186,12,228,36,180,18,19,63,206,35,166,153,163,101,204,209,104,150,58,40,188,132,60,210,234,171,2,129,214,73,231,19,16,148,218,179,139,48,252,215,38,134,65,201,39,54,50,154,141,12,163,34,0,152,226,22,24,242,50,45,162,33,25,41,9,210,36,134,1,57,11,221,4,42,97,208,69,115,157,52,160,2,209,36,38,79,98,9,148,78,27,175,116,221,64,74,134,217,9,79,82,13,20,133,70,226,161,139,24,175,209,186,130,91,166,113,197,18,233,197,53,48,148,184,139,249,242,185,68,7,19,24,65,216,230,196,93,128,33,0,123,106,128,158,206,22,0,72,168,119,189,234,37,68,33,22,92,11,114,44,130,105,6,80,99,121,105,117,52,45,40,226,75,90,120,204,99,84,146,152,81,113,71,113,182,169,156,28,77,196,199,203,69,149,50,229,210,72,169,78,37,25,100,172,70,41,103,104,13,165,100,3,6,232,97,57,59,178,83,150,123,194,108,27,201,230,18,205,143,132,78,237,114,101,213,218,168,255,178,121,164,233,176,111,168,117,102,82,45,217,225,166,196,79,108,32,7,156,89,113,215,222,178,76,56,100,27,132,29,116,173,239,88,156,166,201,48,234,4,147,97,12,195,102,152,77,19,248,104,70,175,72,188,207,64,209,2,223,145,5,100,28,223,180,35,94,190,73,151,190,118,30,229,108,177,207,73,138,0,70,69,10,18,21,195,120,164,184,197,133,152,109,11,13,36,52,120,8,131,192,45,174,135,62,58,162,122,198,224,191,5,89,4,48,20,1,231,150,24,102,232,194,136,95,154,101,78,19,82,211,139,40,171,177,65,79,230,242,118,176,26,37,18,221,94,4,33,96,205,21,167,96,155,43,91,9,67,122,213,145,94,99,212,98,23,74,44,7,125,15,16,236,194,248,41,46,90,4,70,33,118,152,182,61,165,51,6,192,128,41,230,13,188,133,90,124,131,218,56,204,182,26,85,96,180,163,253,86,48,70,101,12,227,62,131,152,75,201,145,119,79,61,3,61,246,49,123,218,239,67,25,120,172,229,99,86,22,154,143,224,99,24,181,167,253,48,168,244,123,224,239,227,100,255,97,182,35,43,19,116,9,101,20,223,246,229,145,61,240,51,33,159,237,196,238,121,172,231,76,243,129,175,15,234,208,67,251,251,168,135,50,148,209,114,66,55,220,130,202,160,71,52,102,239,125,101,132,225,251,206,135,63,240,149,241,174,72,64,195,246,236,71,191,50,150,161,12,143,210,3,26,222,135,6,237,83,134,153,80,31,151,56,144,152,64,157,212,1,159,247,241,143,243,57,16,154,128,146,203,242,13,94,80,187,241,17,134,129,80,11,229,146,143,176,235,19,18,73,27,123,66,137,168,147,45,146,217,145,33,105,8,15,193,4,73,251,132,172,51,9,192,168,145,129,136,132,164,75,157,197,0,9,182,64,33,128,105,187,115,121,137,79,75,179,235,2,154,84,203,25,210,225,174,87,162,130,8,131,181,158,42,47,174,48,27,167,128,1,120,176,7,245,114,66,188,240,161,90,88,7,174,177,8,133,120,160,24,8,0,21,40,8,30,130,7,107,251,9,22,49,39,175,152,11,175,24,188,51,132,7,93,168,130,69,88,176,111,224,154,208,83,163,241,130,20,55,146,149,107,255,153,35,222,203,140,242,192,35,206,217,7,56,220,7,113,131,56,200,120,140,202,105,149,62,12,189,125,72,10,67,204,182,63,196,14,219,24,151,229,152,9,69,84,163,125,168,14,101,200,182,24,216,135,199,17,6,125,152,137,81,177,62,87,90,25,73,228,138,125,192,143,101,232,138,3,168,45,142,16,191,85,20,191,176,224,8,19,209,11,0,216,7,48,16,69,56,180,197,174,24,174,115,169,197,91,84,163,27,192,4,122,64,162,104,185,65,118,33,166,2,124,31,45,211,15,209,98,135,78,155,64,205,106,42,175,152,145,132,160,167,190,193,64,182,56,27,64,19,39,73,24,6,104,40,46,52,248,47,123,170,136,21,192,132,58,121,134,134,105,142,19,97,167,131,25,136,8,3,52,15,12,161,178,57,12,154,153,135,95,233,52,39,73,171,154,225,46,195,146,19,158,232,9,194,249,28,70,48,157,47,1,3,66,216,133,28,194,45,0,56,200,242,114,10,96,176,7,117,104,72,123,128,132,195,43,7,93,88,34,133,160,162,155,136,139,29,130,132,117,120,5,45,112,10,202,255,227,153,184,240,66,3,195,181,69,224,60,6,163,5,57,225,69,25,18,12,21,128,20,42,0,3,149,8,141,195,177,148,195,96,157,225,184,195,93,220,7,225,48,183,29,187,42,82,193,7,157,36,28,157,4,49,225,56,141,52,129,4,243,137,4,162,4,142,90,20,3,104,224,133,124,136,4,24,168,57,192,146,43,192,170,69,74,108,185,149,228,202,174,152,197,93,236,202,174,8,3,125,152,22,176,12,203,48,240,62,154,169,23,226,81,45,228,96,16,11,220,57,154,112,137,248,25,185,10,68,12,45,188,8,136,176,72,182,64,17,138,209,162,11,241,136,113,212,7,147,201,4,17,50,17,46,144,138,255,225,191,71,123,136,253,241,58,61,33,17,138,81,199,20,17,27,45,250,15,155,185,199,153,107,151,38,73,43,223,176,144,214,232,153,156,153,18,229,50,138,9,3,131,90,136,132,90,19,61,132,196,54,102,195,53,135,212,53,195,83,162,96,192,64,180,97,145,133,84,135,66,40,132,3,104,205,29,98,39,130,144,33,245,130,169,245,130,132,42,240,60,55,236,202,163,255,129,201,66,8,175,211,179,163,228,59,12,77,97,30,166,170,150,48,208,73,203,17,172,85,25,37,179,130,42,121,208,73,165,32,202,232,1,44,99,129,4,225,32,74,231,216,197,73,208,135,75,72,138,173,154,178,135,195,22,207,200,74,97,152,191,176,228,202,125,176,78,251,188,69,82,108,9,179,180,207,100,168,135,99,89,146,105,17,144,93,200,158,2,196,172,122,25,179,203,82,187,253,112,9,149,148,138,171,72,3,177,49,139,21,232,75,4,242,186,168,0,193,226,130,134,100,248,132,45,112,173,253,9,131,100,80,134,103,152,63,19,1,209,174,177,136,41,42,155,132,64,197,142,161,10,140,144,160,165,153,50,100,154,71,122,25,179,7,172,25,20,122,21,11,113,33,214,208,192,93,240,54,88,147,53,174,16,201,214,220,25,45,4,3,92,35,188,69,152,47,145,42,7,48,16,67,180,217,33,27,80,7,99,128,133,66,88,167,178,89,41,133,108,54,96,128,66,96,88,132,66,96,176,90,80,4,213,188,197,159,242,11,72,233,42,205,144,140,145,112,150,112,171,140,116,255,123,12,198,32,74,163,44,15,171,218,148,208,8,131,124,208,73,74,209,7,36,244,74,209,64,13,242,144,142,166,244,67,81,2,203,241,35,26,137,138,201,96,1,172,252,92,196,165,20,84,253,12,61,101,160,69,75,245,195,243,89,74,77,133,195,76,160,135,39,97,143,4,132,29,0,105,203,129,122,151,122,153,199,103,74,179,123,249,203,144,200,136,135,144,213,200,36,145,144,128,139,255,186,145,51,80,57,147,249,168,11,169,136,76,128,134,93,149,24,130,241,58,22,145,1,136,48,0,132,176,38,89,109,14,176,129,136,9,66,52,19,98,80,81,187,65,39,121,38,162,144,12,21,218,9,83,123,141,72,112,210,45,24,175,241,106,77,174,192,182,88,156,139,185,48,6,123,0,83,39,84,4,94,243,33,117,176,54,139,36,8,46,180,137,0,8,60,117,168,133,66,216,27,138,130,1,179,241,147,133,116,54,39,4,134,45,144,182,206,83,73,174,228,182,10,19,140,34,76,140,167,226,56,231,169,148,237,44,74,195,208,201,201,17,149,233,12,196,106,25,9,239,244,195,217,255,88,134,131,245,74,216,81,37,231,24,37,234,152,13,157,140,15,179,132,6,224,104,13,60,181,30,232,200,74,76,240,79,75,37,6,73,245,84,175,148,137,153,181,79,101,120,52,128,121,166,6,41,185,145,123,172,153,211,143,74,10,40,29,61,131,45,146,10,148,154,145,144,136,136,144,120,131,22,213,34,169,208,206,66,43,46,143,34,81,18,29,204,167,59,142,119,36,32,133,120,3,170,176,208,135,160,10,166,245,64,45,250,167,27,61,22,238,17,213,209,122,137,217,32,156,84,179,137,130,122,84,164,193,139,49,137,33,166,57,200,184,32,67,21,96,72,92,179,135,96,160,182,249,42,7,72,56,0,22,129,138,118,242,10,0,128,132,39,44,132,87,56,88,253,90,32,190,251,219,48,37,211,206,3,189,176,228,54,48,9,140,201,8,179,93,42,14,60,234,150,227,200,201,68,245,220,237,152,183,141,99,156,160,132,67,125,0,154,246,59,68,131,11,14,219,136,132,100,184,4,155,157,196,242,48,203,45,88,6,111,141,4,218,24,142,100,25,141,172,12,134,247,115,190,67,255,140,191,100,184,129,90,140,1,241,211,135,248,3,190,79,187,4,167,204,63,255,243,62,239,147,32,91,140,1,78,148,137,55,235,52,54,185,23,116,161,25,252,168,151,124,160,77,81,57,166,155,163,24,175,80,136,21,40,17,90,69,8,11,37,145,179,1,48,156,48,145,144,144,39,173,253,191,103,208,17,134,129,211,62,225,66,133,48,128,13,170,17,132,200,24,150,66,200,41,147,144,159,43,140,94,82,18,178,19,205,157,81,53,176,50,12,94,91,132,192,104,215,125,173,24,0,104,205,88,92,32,102,139,154,244,82,87,119,165,66,93,120,204,179,97,145,197,13,0,134,132,215,108,40,132,27,168,139,115,221,9,116,133,194,244,218,133,66,248,6,145,218,5,143,84,163,186,128,67,88,19,156,192,232,137,72,8,6,205,128,13,73,128,4,43,227,142,198,49,21,62,172,84,89,220,189,227,80,22,214,225,163,196,152,7,230,93,6,165,80,6,104,205,221,204,241,22,197,129,217,208,179,206,230,241,79,49,208,135,196,80,10,146,77,184,93,56,131,152,221,22,106,241,163,172,255,164,150,58,204,55,24,168,197,150,27,134,231,33,70,81,221,149,229,18,134,90,164,135,147,129,38,79,139,62,52,128,67,98,56,190,116,161,179,154,171,14,69,238,158,6,109,18,130,17,38,154,232,169,199,43,8,29,146,87,131,104,39,24,249,175,117,12,9,70,216,17,28,121,24,158,85,57,167,147,152,114,234,19,131,16,195,139,28,8,168,152,139,118,242,46,79,163,151,138,216,130,151,120,64,183,37,186,213,216,137,159,184,1,176,2,142,93,32,210,34,117,162,28,154,225,29,162,168,173,0,131,39,100,210,93,160,72,153,82,135,45,232,66,118,90,32,45,106,82,88,200,92,186,152,181,157,96,82,2,131,132,66,240,33,114,152,74,251,252,41,54,61,189,193,120,177,174,250,169,199,96,189,215,155,163,125,224,98,175,188,22,224,1,141,37,102,156,145,96,221,108,115,191,173,250,168,67,84,171,92,145,14,1,169,197,48,128,134,198,154,217,226,154,74,211,105,30,65,106,227,67,140,22,112,209,142,80,145,227,198,248,28,52,238,229,45,168,197,219,11,51,220,16,159,123,255,132,143,238,185,104,95,162,192,121,73,147,72,160,41,73,8,61,52,160,135,103,234,37,128,186,23,6,33,38,8,212,65,100,144,4,133,136,71,249,24,136,175,43,214,86,222,19,190,52,155,38,122,60,130,217,136,58,65,3,70,48,25,104,24,76,101,16,32,73,32,76,9,170,8,158,40,8,191,236,75,133,192,100,88,118,162,129,120,185,166,50,8,5,121,96,100,162,153,27,200,214,181,241,9,192,40,140,93,96,4,33,53,138,148,52,82,46,116,101,190,203,33,118,74,87,17,182,7,94,211,97,117,48,182,48,172,215,45,74,230,244,90,132,87,248,6,57,169,212,173,176,129,109,254,66,37,162,133,117,192,33,167,240,97,190,11,61,21,64,138,48,80,88,198,166,148,87,137,141,21,170,226,201,49,28,205,97,12,122,0,217,81,148,83,67,157,36,67,170,197,27,192,212,48,240,144,67,228,36,244,136,15,81,105,146,90,196,1,122,8,144,133,94,73,164,6,131,229,32,154,247,72,237,249,180,15,146,227,12,57,86,157,174,218,170,193,0,228,194,1,22,196,64,134,97,255,104,70,245,41,142,233,189,84,196,34,38,211,18,134,223,123,226,76,228,57,239,245,44,126,113,23,97,96,159,212,122,146,117,28,8,147,186,192,105,142,138,180,89,41,61,201,66,139,176,9,10,106,209,146,105,152,226,34,101,226,66,193,183,168,136,181,185,194,27,40,111,0,211,147,99,219,147,223,186,14,49,0,209,132,168,101,29,149,137,118,185,4,160,177,129,242,146,18,120,114,207,87,10,215,112,46,175,170,86,160,121,229,59,45,132,129,191,125,66,123,208,5,195,35,135,90,80,135,72,32,67,240,222,162,202,93,4,88,64,206,199,91,27,190,81,230,38,45,108,153,106,10,253,220,92,112,13,140,218,200,55,195,120,21,94,80,42,195,33,37,41,83,6,49,56,68,204,57,21,134,187,22,198,64,43,234,165,148,210,158,84,204,0,184,15,67,134,121,184,226,208,147,132,143,66,212,149,84,1,101,88,132,115,121,172,15,115,227,225,57,29,210,144,99,209,144,18,138,0,77,27,200,202,41,75,144,234,6,24,231,177,143,246,0,228,247,200,238,199,146,132,38,225,190,67,255,68,187,242,161,50,255,96,31,243,137,38,106,141,100,131,48,152,18,193,34,25,105,167,252,186,233,249,150,1,38,20,161,242,250,173,32,209,135,0,108,57,136,73,6,163,134,24,76,240,58,185,56,180,41,245,75,61,9,224,240,86,155,63,143,76,62,151,138,160,99,159,209,210,151,183,67,200,28,122,13,160,41,154,163,25,175,7,19,73,186,224,66,46,36,215,37,108,92,101,86,215,69,200,240,114,48,48,87,94,39,25,6,211,39,28,83,207,219,34,108,110,205,102,3,92,49,221,169,245,34,175,113,229,69,21,248,18,163,17,226,52,177,129,90,241,86,21,120,109,103,105,157,218,230,28,164,222,113,197,72,143,81,33,68,239,8,141,63,14,61,76,32,134,87,201,136,216,69,56,87,58,178,215,169,197,76,80,134,48,230,74,76,252,185,247,8,149,221,142,221,106,201,189,87,130,237,73,108,158,209,1,43,155,8,115,95,106,172,128,122,203,95,122,137,143,166,143,151,64,144,105,105,18,18,133,243,180,178,64,246,209,44,246,113,31,97,122,174,14,140,1,180,72,136,105,255,70,27,77,206,47,11,45,111,175,16,3,157,32,132,87,80,180,141,208,135,121,128,6,254,77,134,193,68,162,17,33,83,42,64,239,44,130,17,24,214,248,43,84,8,162,104,223,240,14,3,25,72,229,69,240,23,42,3,40,216,208,9,9,38,138,46,247,86,165,144,195,174,224,194,46,93,154,174,64,230,16,142,154,194,3,134,137,92,7,96,208,66,115,170,24,108,78,230,168,9,134,63,176,5,195,227,11,39,154,97,174,160,112,39,148,72,153,2,6,188,77,66,91,76,236,48,209,2,198,230,9,70,80,138,173,138,132,134,226,56,49,159,163,76,49,170,17,205,132,67,84,46,224,145,37,158,84,21,231,64,134,90,148,52,194,33,242,73,124,166,29,179,190,78,91,247,100,208,221,67,132,67,49,8,213,229,216,5,235,89,132,172,220,30,65,122,14,222,174,123,125,51,12,42,249,247,35,11,16,11,172,172,72,96,147,37,9,134,139,70,16,244,1,31,3,97,135,38,161,135,134,111,15,223,192,51,245,129,18,253,248,151,215,159,199,153,238,238,179,32,155,240,142,11,24,255,254,47,117,180,9,28,208,203,41,90,129,85,81,1,21,120,5,118,232,235,13,105,242,68,31,76,13,65,3,111,54,7,63,232,9,132,88,188,132,232,24,61,97,11,246,197,111,240,63,139,48,64,204,129,48,64,98,57,161,2,177,16,14,134,138,157,200,71,111,53,154,109,147,19,87,95,220,42,90,122,87,215,194,21,120,107,17,6,136,72,229,116,237,34,167,46,12,0,24,1,96,0,136,1,32,0,36,123,240,224,5,91,84,232,91,57,132,15,21,2,72,104,108,34,72,72,181,212,173,83,7,108,75,128,142,15,85,166,84,233,18,128,150,45,48,180,204,132,177,8,70,152,48,54,180,128,17,6,38,82,152,51,145,48,5,205,137,41,210,25,49,103,134,101,122,9,96,223,153,48,67,47,73,18,122,166,170,212,51,103,22,97,10,182,207,105,38,76,60,37,41,115,186,79,82,164,72,85,213,10,77,219,53,153,188,175,47,135,13,83,27,73,174,203,125,195,156,2,200,164,207,237,209,72,104,238,154,21,70,53,146,48,76,104,209,10,197,171,114,95,218,72,48,96,128,255,185,161,37,204,100,199,29,149,157,17,150,54,24,218,163,194,70,39,6,45,218,176,102,0,202,12,75,10,134,137,23,213,75,134,73,67,43,140,76,24,232,93,163,187,182,110,45,76,146,236,96,163,133,207,150,103,56,6,242,45,56,182,196,8,211,28,57,116,228,48,14,196,88,129,124,5,0,49,105,36,225,184,49,73,140,129,24,104,86,192,160,242,202,213,138,48,153,50,73,202,68,47,89,178,245,76,111,152,127,69,69,197,1,73,43,12,136,201,20,67,140,27,105,220,0,64,120,214,69,7,221,13,200,221,160,92,12,91,136,145,32,114,192,253,150,24,105,152,120,38,76,84,48,168,96,128,10,9,69,178,211,34,97,40,162,197,101,138,48,20,128,1,216,165,184,226,126,45,134,215,17,48,18,201,168,203,72,35,169,179,200,70,1,28,160,66,74,49,194,99,207,34,193,20,82,75,57,55,181,228,80,0,54,76,36,35,60,145,168,163,142,46,240,236,194,144,75,6,240,245,18,12,138,200,68,133,76,151,133,1,6,77,134,217,20,213,81,97,84,37,9,81,57,45,85,255,214,75,251,176,135,137,98,103,70,21,149,36,103,98,50,15,155,46,41,35,134,13,91,144,101,214,37,152,8,181,86,85,152,92,18,9,113,169,41,3,39,82,169,237,163,140,36,124,41,147,140,103,145,45,114,134,163,163,185,181,203,97,106,45,226,40,112,152,225,36,42,12,91,40,138,88,36,129,34,38,155,48,200,136,6,28,47,136,33,227,85,97,169,194,118,9,108,188,156,150,76,158,143,17,103,232,112,173,189,102,97,112,20,202,102,161,172,183,57,135,220,131,50,132,33,131,24,209,138,17,6,132,207,82,11,221,1,9,66,152,224,66,146,32,20,195,125,55,132,129,6,124,201,232,3,205,123,241,229,20,131,10,42,48,228,109,67,49,220,144,173,12,9,26,168,173,188,10,78,187,239,127,255,221,96,221,13,139,204,22,12,98,165,205,150,102,71,48,112,104,67,78,54,137,184,5,33,90,118,164,34,0,251,165,164,80,138,0,28,208,208,67,17,253,248,35,48,187,168,83,78,48,80,166,180,49,126,13,25,99,143,61,192,44,178,78,45,68,238,226,16,67,6,164,4,255,198,199,31,143,180,75,73,186,56,180,82,71,45,177,228,20,137,133,128,57,147,48,97,208,132,9,50,89,206,201,150,154,72,21,133,73,175,29,145,165,12,214,244,96,157,245,214,250,108,189,167,83,202,124,9,67,36,85,63,53,84,90,140,69,134,201,46,104,94,146,26,61,138,165,229,232,93,3,58,85,143,103,152,112,53,183,89,174,165,149,24,90,118,17,214,230,80,33,78,182,5,24,49,100,230,20,89,251,56,254,56,228,145,239,3,13,105,153,70,2,27,219,71,117,213,149,48,103,189,116,3,61,183,225,122,137,107,184,93,200,42,104,163,161,94,156,166,16,254,23,134,180,104,136,129,198,119,210,62,184,239,13,42,68,183,194,198,14,137,119,45,236,97,108,145,201,48,241,25,63,140,36,55,76,155,147,242,206,241,174,177,117,48,32,184,175,237,176,127,39,123,180,205,231,187,197,230,186,82,184,91,105,54,228,206,161,67,96,156,1,6,226,136,95,6,102,71,54,243,200,225,1,10,97,172,123,202,1,128,193,242,146,240,44,66,142,200,235,0,227,80,202,202,39,35,255,33,53,9,22,229,80,7,146,42,214,145,72,72,100,73,192,8,6,255,158,132,163,142,116,200,41,66,3,218,10,192,68,162,69,80,65,11,129,1,67,59,40,35,21,169,96,69,43,117,154,83,24,168,118,165,21,178,240,37,202,8,145,22,208,64,12,179,4,134,80,66,33,142,97,222,22,54,207,52,198,44,174,162,199,207,92,2,58,185,165,5,83,181,10,13,193,2,215,40,179,164,10,12,147,193,140,226,180,112,131,212,180,144,47,251,80,157,163,120,163,41,92,9,7,49,232,2,203,106,140,35,27,86,137,6,87,188,193,225,110,74,119,27,220,136,33,58,209,130,157,180,36,49,187,104,97,79,12,56,152,86,239,168,131,36,247,5,47,95,227,202,68,124,218,19,159,105,201,203,65,203,34,80,197,144,67,157,134,192,209,118,104,96,132,236,106,39,45,70,180,17,58,136,201,28,193,84,23,172,228,105,200,0,84,106,216,101,66,9,177,48,116,40,0,27,234,200,142,80,132,29,135,28,96,71,27,131,193,71,152,164,139,146,233,226,73,96,56,210,67,44,193,50,123,236,255,98,17,20,41,68,57,214,49,65,68,2,192,99,50,82,71,201,158,164,14,48,96,167,138,78,81,154,210,104,162,5,68,41,34,18,96,184,166,53,131,82,149,171,4,5,133,102,50,155,51,157,169,12,48,124,105,17,102,131,12,107,216,146,42,210,204,70,81,140,26,92,94,8,38,6,112,162,1,157,102,130,231,99,126,115,168,208,32,37,112,116,75,154,226,112,50,25,197,81,49,156,249,196,141,163,134,1,62,98,21,79,25,94,227,11,61,216,41,137,11,145,230,146,191,26,14,231,76,39,143,219,116,229,90,218,250,142,191,180,35,199,70,78,107,65,255,202,23,114,86,148,18,221,33,199,57,102,74,198,48,48,1,83,52,80,139,57,138,107,166,205,166,227,58,102,133,52,120,209,250,142,242,98,32,137,73,184,78,92,200,50,140,174,74,247,189,75,96,38,33,28,11,10,78,98,34,77,165,185,100,33,166,140,159,42,195,163,59,142,5,192,71,31,131,96,73,214,161,11,141,4,113,101,63,90,132,45,224,1,12,96,222,40,104,60,130,101,3,127,36,50,100,34,51,136,255,45,89,233,5,47,168,2,45,140,40,38,51,225,5,36,20,225,196,47,141,16,109,227,2,138,55,209,0,78,131,178,112,156,56,1,195,57,135,162,54,183,24,102,85,248,236,8,61,206,135,22,71,229,131,50,202,216,139,83,134,161,140,67,241,173,77,178,249,91,100,82,85,218,188,12,197,137,147,25,168,19,11,202,216,43,222,38,53,188,226,154,214,148,161,181,76,52,243,37,98,208,135,133,102,149,185,217,200,134,83,165,33,14,113,78,219,42,118,204,198,91,13,122,93,26,96,199,136,235,189,46,168,138,220,143,29,97,128,3,223,113,108,71,46,149,22,241,136,135,137,125,57,231,95,54,139,129,85,17,52,32,69,54,231,118,202,155,157,28,233,232,172,66,138,97,52,242,176,144,176,120,65,154,99,237,66,39,9,99,136,13,212,18,202,153,40,109,11,42,9,162,43,21,103,85,149,118,196,12,248,147,72,200,158,4,143,182,10,45,6,63,146,200,34,106,1,143,123,100,184,28,255,35,166,146,30,44,37,96,40,115,74,124,177,18,49,83,156,48,45,196,128,68,26,146,255,132,60,46,193,19,165,153,97,17,1,22,148,153,162,50,152,162,148,141,177,140,21,219,22,118,18,217,116,6,166,82,5,235,92,216,192,176,183,212,232,131,84,144,146,84,59,142,242,169,187,201,6,45,158,9,220,98,204,166,140,203,65,81,122,3,133,129,108,195,121,3,125,12,39,204,6,5,51,110,214,184,42,221,188,70,169,186,97,213,192,134,147,140,89,153,110,188,174,27,94,237,38,1,82,105,205,43,90,252,65,131,130,98,208,187,148,174,192,164,104,88,196,13,218,131,137,97,76,75,118,133,92,81,74,3,112,3,8,61,200,95,204,138,214,29,135,250,211,73,28,72,12,156,171,139,114,225,156,152,93,96,66,122,27,234,144,10,196,181,19,153,108,129,68,152,169,96,71,104,118,128,222,114,55,33,55,139,171,61,76,98,146,146,0,3,59,169,52,102,69,94,241,163,152,141,236,68,15,185,31,72,236,97,140,3,242,76,29,144,232,237,75,90,2,109,150,104,97,17,36,106,117,181,243,17,9,21,52,44,155,41,68,10,184,189,85,20,197,250,216,160,142,205,201,57,129,25,21,24,67,1,39,56,178,113,39,184,233,246,88,52,208,195,110,109,162,148,17,93,168,41,180,29,106,221,90,14,20,77,94,27,197,24,152,185,138,191,13,20,146,203,109,150,100,28,35,185,153,68,170,107,132,83,58,228,166,209,66,198,25,53,110,228,24,157,162,134,1,7,214,170,100,128,196,240,6,228,72,122,11,179,206,233,66,158,35,134,228,213,55,44,211,242,214,130,216,181,200,0,176,11,66,7,208,206,13,50,129,6,234,60,136,57,109,220,214,22,170,85,95,77,142,142,162,155,255,27,245,100,156,250,90,51,213,36,6,232,35,145,205,30,98,165,172,218,85,126,210,54,171,68,226,1,140,146,60,233,195,42,209,37,203,116,97,11,13,219,35,24,181,88,199,58,20,33,52,99,254,104,100,192,56,96,91,85,130,226,149,202,221,148,64,131,137,34,8,113,52,45,72,98,23,215,92,159,84,2,76,149,160,40,5,199,116,50,219,213,184,246,181,174,41,131,24,94,19,67,216,190,116,153,200,174,91,45,187,248,155,177,224,86,196,48,56,234,137,78,231,124,16,15,188,143,121,64,66,81,126,75,27,234,47,167,229,223,216,192,93,165,154,204,13,192,236,148,121,210,3,93,186,189,125,237,181,246,158,76,124,86,24,156,42,120,11,167,56,26,100,200,3,31,116,150,56,110,44,84,58,221,28,12,135,196,57,190,242,35,65,200,3,85,167,58,211,97,105,165,165,19,104,22,237,72,65,62,13,75,38,114,210,198,101,245,142,99,49,216,110,188,244,5,29,150,82,255,185,255,153,115,171,70,147,171,169,176,243,88,73,239,80,64,131,162,187,153,180,154,170,9,51,37,255,164,105,76,180,113,72,143,224,15,200,116,93,73,220,210,70,124,12,47,197,12,200,44,194,147,88,66,208,0,0,214,129,76,45,249,207,65,12,13,0,156,146,0,86,137,75,180,24,182,181,154,53,145,19,101,92,83,136,124,91,80,244,83,212,168,80,155,44,6,184,73,197,11,194,96,24,36,3,38,232,67,228,13,214,144,165,10,90,144,86,90,28,138,113,40,10,57,253,132,163,112,155,13,144,224,159,60,211,21,193,77,222,164,94,218,176,160,158,36,13,139,121,217,107,201,94,155,180,202,170,116,5,171,204,67,171,208,5,165,192,25,240,173,144,24,92,17,113,29,3,62,232,67,62,56,195,112,100,156,196,41,95,26,154,142,112,172,81,196,25,139,29,49,199,13,68,70,27,164,74,27,205,26,14,108,151,244,8,26,114,160,223,201,249,78,169,136,203,184,212,201,36,116,220,186,36,93,12,168,212,78,33,200,30,226,71,12,12,138,93,44,139,199,161,1,105,4,131,232,80,5,111,144,154,38,181,6,0,228,78,252,12,136,64,205,196,94,213,196,22,148,210,4,58,4,255,239,160,218,198,56,5,178,53,16,93,73,216,48,133,129,140,24,67,204,236,194,143,216,98,48,33,80,172,249,72,3,161,29,48,24,196,58,104,193,5,221,93,180,241,136,74,144,8,137,184,11,223,45,130,53,105,193,78,252,132,249,164,197,184,72,5,142,229,132,104,153,5,35,220,33,26,72,2,24,28,5,86,120,203,61,232,13,62,104,129,162,228,132,146,157,211,153,116,10,134,164,22,81,156,35,57,233,80,155,20,33,250,20,97,24,100,35,24,41,202,48,28,202,37,236,205,98,88,200,234,181,193,216,52,68,130,176,152,163,92,130,60,228,138,97,236,2,50,32,195,49,236,23,82,221,6,173,40,92,172,237,195,161,228,67,62,16,140,37,12,67,70,34,138,38,205,198,71,166,153,193,172,81,176,224,208,180,92,82,26,10,7,114,124,98,75,193,192,78,221,192,66,36,88,188,192,145,122,160,9,121,41,88,117,4,98,189,4,26,78,32,135,12,196,11,177,128,15,50,228,132,149,137,209,60,228,131,48,240,130,111,172,19,133,8,139,10,216,192,6,190,22,0,48,140,255,151,181,88,139,105,65,251,164,12,67,236,72,212,237,8,95,224,76,3,73,132,58,204,149,88,181,4,36,44,137,217,213,194,55,124,204,46,204,149,70,192,128,1,130,12,57,172,131,200,152,216,10,33,99,251,188,68,171,117,201,94,221,4,193,140,74,97,29,69,84,104,211,96,158,1,241,152,5,9,9,202,84,16,133,108,128,1,62,120,70,103,165,6,242,80,75,24,156,83,103,168,74,112,169,81,24,64,2,24,192,13,85,152,79,231,1,38,57,157,65,220,240,69,50,152,30,98,112,197,161,156,129,108,40,2,83,128,133,55,194,128,13,244,137,134,216,192,226,180,9,241,49,37,39,194,97,87,68,2,169,25,199,68,186,132,123,216,94,110,105,13,228,189,132,62,72,66,25,90,66,36,228,131,25,224,132,233,12,7,170,108,84,116,82,156,243,197,217,170,176,83,114,37,70,30,70,71,79,162,84,27,53,68,252,160,151,244,48,207,202,117,35,181,60,200,126,44,226,34,174,231,182,164,71,236,41,136,30,9,75,70,78,84,197,49,228,104,32,229,37,144,22,174,228,141,255,112,32,11,0,36,78,66,40,78,66,228,142,134,16,216,101,24,91,5,1,224,66,28,88,212,169,196,1,120,213,68,144,152,50,1,195,137,232,210,143,152,221,55,224,34,203,188,157,58,192,131,34,116,4,88,202,146,88,61,201,179,169,4,71,76,96,11,241,213,100,72,149,100,164,133,10,28,77,100,48,85,86,132,138,9,189,102,155,136,193,37,152,129,222,92,130,67,26,198,49,28,131,25,100,228,37,224,3,21,186,196,36,100,194,76,64,214,14,33,67,63,30,69,113,29,202,108,228,155,75,64,67,170,92,130,10,56,74,144,17,150,8,73,194,62,104,132,11,133,13,112,216,167,71,90,83,36,196,135,83,96,130,127,32,134,36,76,134,109,98,70,166,100,36,110,72,169,60,60,31,248,200,74,194,229,197,26,145,206,126,14,69,106,76,145,112,152,129,183,125,227,196,185,225,51,176,67,112,72,100,133,96,34,68,138,81,48,32,31,163,70,156,36,228,11,117,204,203,115,192,142,31,206,75,139,184,82,67,44,143,115,144,151,213,85,71,120,4,64,199,53,68,119,60,7,255,182,228,139,66,25,12,72,34,70,62,220,134,156,10,11,101,37,31,113,0,64,83,45,93,236,37,68,255,133,82,5,217,140,175,42,208,197,168,146,83,120,149,68,248,143,177,242,34,92,226,207,46,212,194,46,148,195,87,245,15,48,220,90,92,73,201,200,148,196,48,21,35,138,205,157,6,238,101,40,133,129,48,168,128,53,137,11,101,140,160,97,0,151,53,14,38,38,64,195,36,152,197,25,108,20,38,22,223,61,220,3,62,224,3,25,102,36,62,68,38,227,144,217,37,108,129,217,196,13,193,132,65,38,165,202,229,201,6,62,72,194,12,189,4,61,228,3,83,29,233,99,24,40,12,68,197,79,248,105,232,173,144,50,176,3,106,77,84,78,164,133,50,52,197,75,100,194,81,34,195,25,48,132,20,18,28,19,89,211,22,9,67,50,4,7,27,250,96,171,56,202,60,32,3,36,232,23,15,205,32,199,234,9,38,128,193,49,228,3,52,21,12,38,202,70,50,16,204,197,241,230,241,141,198,67,6,3,193,18,151,118,246,38,38,200,75,27,133,7,121,34,7,26,252,139,255,244,52,45,239,40,146,238,104,143,188,192,142,212,82,135,66,56,132,199,89,7,127,64,81,120,112,173,191,224,128,112,24,71,70,177,138,60,204,195,60,0,231,34,60,67,61,60,166,111,88,72,98,68,130,173,190,37,85,74,33,226,24,13,139,185,68,135,88,140,194,60,68,135,48,152,136,130,68,219,37,211,147,32,68,24,228,79,91,110,232,133,141,229,135,170,3,67,48,80,88,150,140,135,145,132,218,181,80,75,192,26,5,129,201,136,16,2,95,41,205,37,212,4,79,108,197,79,204,67,50,16,101,154,68,197,147,153,214,188,26,67,51,204,235,188,230,3,62,200,43,189,206,107,150,58,69,26,208,3,193,116,166,83,192,212,37,180,69,118,146,214,110,128,86,94,104,27,57,13,161,75,22,214,218,216,96,21,41,67,48,176,195,109,128,129,55,130,193,60,16,140,50,48,194,236,209,195,49,28,104,85,226,132,163,216,38,12,180,74,69,24,71,36,72,228,24,93,200,172,56,10,50,92,239,126,206,44,105,34,33,233,200,131,78,68,194,34,128,129,243,153,111,70,146,36,255,114,113,14,73,154,14,23,169,78,67,70,103,36,156,223,113,162,72,67,72,15,160,81,71,182,84,210,139,8,90,121,62,72,4,219,0,239,40,4,86,5,149,30,5,149,244,116,224,205,225,192,10,144,14,105,88,217,240,25,237,60,60,36,50,68,194,60,152,225,24,33,75,230,216,42,84,234,142,109,38,240,76,92,198,22,40,2,85,157,12,34,253,12,0,10,110,198,168,196,226,134,165,49,204,165,135,226,136,49,1,131,90,182,229,199,24,195,92,193,3,66,96,157,61,196,3,6,118,29,152,34,176,91,181,80,12,40,130,209,108,129,181,145,146,183,130,65,170,57,209,165,128,65,62,36,195,52,158,129,98,160,163,62,216,219,99,212,110,51,96,100,237,222,107,237,198,235,237,30,67,238,190,68,101,86,219,101,101,135,62,204,3,82,156,142,106,5,9,50,236,195,113,178,150,108,50,108,71,124,41,236,93,83,103,220,108,103,46,150,158,32,36,36,200,134,10,8,195,30,11,69,147,57,197,152,97,105,124,10,156,33,171,134,22,168,64,224,56,233,245,30,25,110,32,138,255,71,6,114,223,196,152,106,1,5,24,216,0,216,184,208,81,60,167,103,48,204,156,222,215,245,6,67,140,153,78,67,62,38,110,188,33,173,182,106,47,11,67,208,130,198,31,178,103,213,2,0,14,0,26,116,24,192,169,182,72,172,53,79,242,80,146,115,156,72,215,6,149,211,82,71,26,160,151,239,56,196,13,108,87,12,104,82,193,188,170,48,140,178,125,201,169,62,4,67,24,200,236,161,220,134,221,174,11,135,248,215,128,150,202,181,93,6,170,77,76,197,48,24,202,89,73,16,249,34,60,104,29,228,174,3,36,196,0,134,150,29,45,52,107,45,128,29,60,136,213,58,192,3,24,0,64,140,52,208,61,240,26,175,77,172,5,69,91,50,218,48,232,42,205,253,218,192,70,61,172,141,153,160,62,152,143,183,168,13,50,116,230,32,63,134,61,224,131,61,228,3,61,220,3,51,196,67,62,28,67,60,52,131,49,200,107,70,214,177,16,237,241,205,234,3,69,59,20,108,36,198,161,48,159,25,80,178,217,128,25,50,4,156,163,96,198,13,36,14,245,26,198,79,8,3,255,61,160,65,11,109,89,93,132,1,12,229,67,72,71,66,52,156,116,71,224,64,232,96,6,77,196,103,108,69,30,12,160,193,53,229,131,60,252,108,154,49,42,233,16,95,109,249,16,62,24,45,193,156,207,151,252,22,38,235,195,253,138,113,48,168,0,46,195,5,82,94,47,38,92,92,157,182,10,82,254,103,244,42,170,27,70,167,48,211,153,108,132,129,30,157,223,13,140,106,24,100,51,123,66,199,169,106,85,115,192,142,28,185,65,73,177,139,239,116,51,165,246,161,127,24,192,172,129,54,205,201,139,60,104,219,223,16,223,187,174,81,189,6,195,49,184,175,14,114,10,31,99,66,66,196,240,195,226,68,236,213,68,52,185,88,149,160,8,126,108,200,42,153,159,75,96,232,146,172,131,65,144,216,88,61,52,60,232,66,57,60,183,209,200,136,135,170,131,53,153,213,143,212,105,215,141,37,11,161,88,7,250,173,181,241,196,34,220,111,78,168,128,60,56,17,52,162,35,107,34,214,85,184,69,62,96,194,151,154,133,28,199,174,61,144,97,51,196,235,61,204,247,61,232,195,255,37,60,197,51,213,67,48,144,211,43,191,4,52,212,3,165,204,105,48,228,3,93,236,131,243,250,150,50,220,151,53,57,10,24,24,128,76,48,204,249,224,196,249,96,10,69,235,137,187,36,196,248,34,3,70,246,196,62,80,137,75,112,30,80,184,158,155,18,20,24,89,53,101,104,97,91,179,118,116,26,31,46,59,138,37,212,233,24,85,70,101,104,65,128,171,4,164,0,236,79,72,197,172,176,237,129,7,3,67,206,138,68,22,223,47,35,118,209,210,173,209,146,111,47,119,20,117,220,17,26,196,36,130,40,136,77,29,200,130,192,151,153,240,11,245,193,192,78,70,71,129,24,64,26,84,218,1,132,193,70,149,112,154,53,36,46,159,161,103,16,31,90,151,240,129,199,117,221,86,138,109,42,142,211,61,236,80,146,15,137,180,152,210,236,145,2,113,4,146,76,135,213,137,103,128,26,110,68,131,213,88,242,51,207,56,183,78,28,211,92,233,66,36,172,140,140,200,131,66,207,37,36,20,99,85,81,16,95,196,232,253,22,130,34,88,132,235,33,67,6,45,200,53,89,53,255,85,160,69,55,106,69,78,148,158,21,225,131,51,196,195,61,184,186,49,88,2,25,30,3,48,68,178,49,224,3,150,82,81,52,112,166,192,212,236,231,144,69,52,20,231,198,170,177,75,20,79,73,63,184,89,236,182,184,56,17,57,89,194,77,80,47,79,175,16,61,104,136,51,122,75,140,74,79,30,119,68,72,63,101,254,149,138,239,130,145,50,68,131,228,140,187,227,32,3,48,64,248,49,12,229,55,18,150,81,152,141,24,64,67,143,99,6,105,188,170,51,148,48,50,196,195,112,164,185,51,236,41,46,63,36,221,122,134,112,128,112,48,188,172,166,172,121,210,188,215,74,38,76,78,72,17,14,136,103,130,164,90,208,37,69,242,72,130,163,37,72,31,106,179,197,55,76,208,80,135,236,120,28,50,52,195,70,221,3,86,59,195,61,208,131,62,220,235,81,150,112,189,234,131,62,212,107,60,144,225,70,161,249,127,189,169,200,190,150,76,88,155,250,176,196,212,113,8,202,145,39,199,112,12,24,88,247,19,35,32,57,36,219,219,189,93,57,76,70,206,80,232,135,198,213,255,61,32,3,57,76,55,152,106,32,95,92,144,85,119,122,167,127,73,151,64,130,8,137,144,160,254,198,25,152,1,36,132,1,83,77,84,182,43,248,62,220,46,62,40,130,37,60,234,49,92,2,36,4,73,247,226,116,94,56,163,222,124,161,51,237,195,9,167,80,158,62,6,101,44,53,181,144,19,217,235,68,43,79,2,61,172,16,52,0,44,38,42,248,100,72,66,140,22,148,69,138,10,157,23,50,222,179,208,62,196,52,221,200,171,48,8,42,24,48,21,61,46,195,212,111,134,183,92,2,57,69,66,60,120,248,81,110,148,56,35,23,70,198,195,26,182,202,46,60,170,192,95,34,71,186,245,163,118,5,62,236,33,104,143,248,180,168,128,199,65,71,202,101,237,236,132,65,122,208,84,121,177,167,211,182,17,12,40,133,129,37,12,100,11,85,126,199,180,200,95,62,76,99,100,189,226,67,106,207,107,219,30,37,70,202,195,211,199,171,171,219,192,48,136,138,173,158,193,134,72,161,171,93,27,71,8,183,74,5,183,74,177,200,67,0,67,254,72,58,137,149,195,72,12,16,255,255,148,195,46,96,135,131,77,4,64,172,83,7,76,160,61,120,6,239,177,219,69,78,93,48,117,139,0,68,148,24,81,197,196,0,17,13,76,92,180,81,209,162,93,96,32,130,201,23,9,70,24,27,96,192,136,1,19,230,152,164,51,145,34,93,10,150,76,88,176,72,251,38,74,220,183,239,222,177,123,243,98,134,129,121,73,230,177,121,144,84,216,192,153,19,192,190,149,90,192,40,203,196,148,106,213,137,201,134,193,0,35,12,18,178,165,19,247,133,185,33,214,134,150,27,54,194,152,129,17,99,37,152,76,202,170,18,187,148,15,210,79,125,249,144,9,51,35,239,107,206,125,248,32,109,129,49,120,240,22,48,125,173,38,142,184,47,222,49,196,77,131,25,195,135,79,222,37,148,97,74,134,17,6,55,103,24,101,96,20,73,130,100,38,88,48,125,193,240,25,147,71,153,178,48,121,193,144,229,11,134,41,216,165,97,175,145,33,195,151,239,146,48,97,50,123,11,203,39,236,88,205,99,49,143,197,80,174,252,98,196,24,97,0,172,197,161,252,0,140,3,202,183,60,143,255,1,192,128,138,231,55,178,195,88,113,61,198,13,49,49,96,168,16,43,49,192,242,242,243,242,229,163,156,111,30,190,187,205,226,233,155,127,151,190,179,123,119,99,147,239,152,249,238,57,67,24,24,0,216,174,164,193,162,83,65,176,45,180,208,194,48,21,12,104,47,193,11,97,8,192,128,21,12,216,110,187,13,43,4,0,24,131,14,66,102,29,114,130,209,165,156,17,13,82,103,29,21,21,137,8,18,123,90,4,70,157,129,14,58,232,158,96,80,100,8,152,237,170,106,174,170,24,106,81,68,139,69,106,137,100,11,136,84,200,231,12,245,80,26,11,165,96,132,145,4,141,48,134,153,39,24,75,240,185,228,177,166,82,11,6,30,72,34,17,6,165,41,229,35,51,12,45,190,220,71,139,51,20,9,3,12,122,166,82,76,49,101,134,1,3,25,48,146,146,228,177,125,96,64,11,134,45,110,0,3,45,204,10,109,75,31,52,168,82,70,30,222,30,5,70,159,122,192,48,237,75,200,48,89,201,134,45,108,56,244,82,59,39,146,68,159,102,32,249,115,203,99,226,193,39,255,18,57,89,93,105,159,27,152,82,70,140,51,122,162,47,159,125,230,50,42,53,75,42,19,102,50,217,22,137,228,152,99,144,145,9,31,100,130,57,230,18,121,144,137,4,54,221,46,41,246,146,46,47,81,238,134,242,202,107,14,65,237,208,88,46,195,181,180,139,97,188,246,192,67,79,67,112,99,232,22,86,0,42,74,240,218,107,99,56,128,165,123,238,153,172,153,221,234,219,77,30,103,236,91,13,159,121,154,169,55,85,124,134,101,13,31,140,8,3,0,51,3,214,26,76,139,65,211,131,106,5,238,56,228,48,134,0,190,141,23,189,120,191,5,0,12,18,225,73,72,69,117,202,81,199,160,120,116,89,104,29,136,60,54,168,197,27,213,9,217,32,121,74,222,229,198,93,218,141,72,72,137,50,162,74,139,142,192,56,114,17,45,72,42,41,18,180,98,40,43,104,205,34,121,41,140,96,70,178,68,31,175,168,218,167,52,69,44,171,12,140,51,96,192,36,159,122,183,118,181,106,45,228,4,35,18,121,244,145,21,212,156,96,16,99,159,97,10,37,138,164,155,152,218,199,255,134,65,239,22,43,80,194,194,232,187,164,122,214,157,136,24,168,145,129,164,25,123,142,201,199,18,72,244,185,116,31,51,44,59,186,36,244,194,248,116,109,0,134,17,240,207,97,33,185,36,146,203,194,56,3,45,48,48,225,108,34,49,244,209,203,180,212,142,105,134,157,122,9,134,237,81,248,242,49,230,30,97,158,62,214,140,161,8,110,38,89,100,128,65,205,146,97,45,249,45,12,141,169,83,110,34,237,196,184,22,220,234,202,59,30,0,232,197,114,111,57,243,180,91,190,189,3,224,61,32,146,90,127,13,88,192,122,235,115,38,62,196,227,113,70,158,123,229,25,208,24,100,238,73,79,249,232,110,104,56,186,65,35,36,91,194,12,145,143,65,139,24,58,116,0,239,92,76,60,29,170,16,12,114,4,143,120,160,236,69,54,179,199,142,106,166,14,4,37,136,70,240,128,7,48,224,49,16,117,220,227,32,201,168,5,67,108,22,9,246,48,229,34,21,17,210,69,96,128,36,48,108,65,17,188,0,137,8,87,160,21,173,172,68,40,43,169,13,48,136,117,137,129,209,163,255,113,85,131,73,217,60,17,12,148,44,11,6,247,248,156,60,6,211,38,146,236,2,89,201,202,71,227,146,97,165,196,196,224,12,147,24,198,62,50,129,143,96,44,104,17,151,48,67,229,234,166,41,194,12,166,126,245,27,163,10,208,240,24,104,236,38,30,188,178,15,14,51,229,184,187,129,193,50,119,11,212,97,46,103,149,53,2,131,110,126,57,134,37,44,3,149,51,156,201,6,139,216,93,155,152,241,71,51,248,196,24,239,91,156,250,144,225,147,123,32,227,46,239,83,22,36,6,20,186,152,112,105,88,245,106,221,31,137,210,60,141,153,7,13,211,1,224,197,186,19,58,108,245,237,12,199,91,142,24,192,149,160,243,168,160,126,125,171,30,120,90,57,189,241,116,40,93,98,192,193,181,174,19,6,52,36,235,30,141,153,204,49,191,134,15,30,194,206,95,171,169,151,61,118,3,131,140,160,135,67,42,104,88,119,208,163,191,161,17,2,12,19,20,160,34,10,241,191,228,161,135,60,226,217,14,6,45,8,15,121,156,168,28,181,16,19,101,200,97,179,114,76,140,59,35,255,178,160,64,50,24,51,122,201,3,24,43,42,25,36,232,41,17,21,28,192,78,49,160,197,34,58,178,139,161,21,13,0,194,122,19,47,6,9,6,73,84,74,55,241,121,226,62,244,209,184,198,237,132,163,251,200,71,208,96,112,137,147,16,5,12,4,3,3,177,130,97,6,78,93,177,163,59,25,70,36,20,33,143,69,128,1,18,190,42,216,173,90,218,210,140,14,35,25,106,233,148,73,218,2,134,27,36,35,167,153,88,149,80,97,96,70,59,174,101,37,73,69,35,61,116,58,31,223,61,17,6,93,178,196,51,114,186,19,125,172,100,119,173,52,148,156,50,145,85,177,118,84,163,52,249,75,48,108,64,84,142,102,84,25,91,250,220,25,136,245,38,173,164,5,12,106,109,233,215,130,113,6,124,216,67,50,247,48,6,36,106,115,9,64,90,162,25,137,67,134,37,60,202,140,96,116,194,50,153,234,220,97,11,54,25,162,92,226,12,253,195,22,182,198,163,60,73,176,146,17,103,144,4,35,36,49,185,236,157,242,120,215,18,166,36,36,17,137,205,10,19,34,150,181,150,255,123,218,115,9,219,249,7,126,242,177,143,125,244,113,15,188,76,166,94,249,24,208,189,118,131,30,134,117,8,65,54,160,16,135,34,134,208,48,40,2,66,15,90,203,43,20,241,10,254,89,231,58,132,216,2,65,5,8,128,75,88,208,30,241,104,198,46,116,81,11,111,196,12,31,194,32,135,46,214,17,35,137,88,130,68,234,48,134,139,196,244,19,118,232,194,69,232,213,130,157,118,70,17,144,116,132,22,188,232,91,48,98,248,180,99,168,96,54,151,41,139,100,46,170,159,140,254,231,46,186,253,90,62,216,1,12,75,240,17,18,51,237,18,48,38,227,140,70,194,245,115,41,124,210,231,48,1,9,161,152,41,166,138,16,137,179,226,17,9,75,232,194,118,242,184,7,48,64,2,26,28,86,170,36,52,212,20,38,142,58,152,165,194,224,64,131,241,219,198,2,101,150,110,218,81,169,221,4,3,189,94,108,137,124,36,67,17,246,16,70,79,80,98,137,187,221,109,47,151,128,132,161,202,50,199,65,150,205,36,159,163,107,68,119,247,69,27,16,5,54,201,144,205,49,200,255,100,153,144,70,194,12,4,51,134,101,86,242,98,179,157,97,178,96,128,220,153,132,122,6,64,110,173,115,165,145,73,39,102,35,216,75,132,65,176,18,142,68,192,234,124,6,200,97,226,139,144,35,138,37,32,77,148,202,38,40,121,205,11,64,247,226,213,55,49,68,98,211,87,106,37,101,79,121,0,140,121,232,12,173,236,155,75,54,173,105,94,146,135,123,98,104,15,199,174,131,143,255,208,75,214,199,128,38,61,104,203,12,222,50,131,214,255,49,6,124,238,65,220,244,68,164,36,102,28,140,255,180,80,8,230,30,9,12,49,44,4,45,188,17,67,193,72,136,218,130,25,232,64,61,150,206,238,174,131,22,237,212,69,189,4,66,142,149,77,228,99,21,132,153,141,160,105,14,21,245,83,29,64,26,97,134,18,3,131,34,33,84,161,68,179,132,10,186,25,9,120,220,64,196,53,110,218,163,238,242,171,122,228,67,215,119,25,150,124,158,216,19,221,238,38,183,198,104,198,215,236,161,143,99,0,227,30,40,89,193,226,10,25,180,72,236,2,176,65,195,132,137,231,65,182,255,97,57,11,18,48,128,218,209,204,0,215,110,38,21,168,73,59,9,142,23,97,131,232,100,25,51,11,26,35,167,180,176,227,141,37,237,91,38,57,3,60,142,193,9,99,48,210,139,62,81,172,232,80,146,52,181,120,209,6,173,60,148,217,82,186,181,148,111,205,18,187,43,228,238,40,107,103,69,143,6,37,195,34,169,86,110,64,44,195,5,195,25,150,56,3,26,22,73,217,69,30,99,119,109,136,9,157,53,105,153,86,150,154,208,202,178,68,217,47,113,140,186,71,2,19,151,104,195,104,136,66,166,79,163,121,178,129,149,91,27,130,1,47,3,144,167,127,215,161,244,169,251,118,165,177,132,238,18,177,220,14,121,188,124,188,43,9,83,12,125,83,222,107,145,119,29,242,132,193,175,244,26,150,237,108,183,240,123,184,152,70,125,125,160,61,230,241,23,107,42,71,154,206,57,118,195,6,5,210,8,21,2,65,132,168,197,182,6,181,5,225,255,15,66,151,175,72,12,20,104,193,132,128,247,27,234,248,23,48,80,164,142,251,74,228,200,10,188,135,6,75,102,143,103,44,255,100,33,234,192,153,206,184,67,149,140,8,41,133,187,144,16,24,118,33,39,121,0,52,51,248,128,1,36,158,243,197,202,223,74,31,243,160,228,110,240,193,12,190,252,150,50,245,106,100,111,143,9,0,159,8,154,184,2,6,156,5,51,142,42,24,136,38,18,180,64,24,20,97,54,20,129,50,192,0,24,232,34,119,204,128,116,140,230,55,62,71,168,252,102,48,12,133,114,108,224,57,250,70,80,128,140,48,174,197,59,198,40,58,48,195,36,96,64,209,216,12,61,44,1,30,238,134,96,246,172,233,108,192,12,238,6,13,8,131,45,228,132,45,70,42,108,34,138,206,54,240,37,166,174,149,118,167,239,182,174,206,250,198,108,34,161,115,140,33,234,212,110,113,74,77,10,5,11,144,32,231,8,233,40,9,173,44,239,4,139,236,182,68,176,16,143,13,60,71,110,206,64,240,22,137,209,232,5,144,38,139,40,196,194,66,64,143,241,130,105,242,108,41,12,182,224,120,46,1,152,40,205,93,202,163,178,230,208,150,174,165,178,170,131,241,222,229,218,228,5,19,122,13,201,116,255,131,94,226,33,245,44,106,159,130,129,25,82,37,31,154,97,184,192,69,154,16,132,97,164,201,154,34,4,66,134,102,185,178,35,34,28,239,0,68,113,17,104,129,247,2,17,219,12,96,68,56,104,245,22,162,22,116,33,31,228,129,33,72,198,221,162,163,130,228,33,30,110,132,28,48,108,30,188,65,101,128,161,22,66,36,39,154,35,191,136,13,161,134,102,35,136,70,30,204,64,5,200,166,170,210,66,242,80,2,6,142,65,226,50,42,24,238,225,94,110,69,113,38,67,31,248,229,193,240,129,95,248,5,54,16,110,224,116,109,31,244,226,18,230,33,61,92,3,106,118,225,18,20,193,89,80,99,79,184,132,89,10,199,89,224,12,31,140,204,206,106,163,44,88,208,142,88,112,5,167,172,25,199,104,140,238,38,58,0,32,111,234,7,45,110,112,229,76,98,164,142,193,6,122,34,231,142,102,200,128,10,144,82,138,140,70,199,36,220,206,6,184,142,208,6,233,211,20,97,238,94,98,136,178,174,12,99,98,107,156,78,197,142,161,19,182,198,237,32,135,8,9,205,108,32,255,7,31,172,144,142,32,193,5,219,64,89,214,112,39,229,198,209,20,205,139,154,230,12,146,197,119,12,71,89,20,105,178,232,12,12,2,104,122,150,3,68,98,64,38,214,98,242,198,162,90,210,98,5,174,197,34,202,195,123,146,42,18,192,99,242,216,2,144,152,131,127,110,96,160,52,36,6,190,231,152,118,3,225,226,99,232,238,129,215,124,66,31,146,225,30,236,193,25,112,232,94,120,109,130,44,177,4,75,8,122,142,132,108,8,161,47,5,202,246,2,96,73,8,8,99,4,232,34,182,43,157,240,129,23,104,161,219,110,145,32,188,47,103,216,197,26,139,9,25,6,66,32,202,107,33,28,162,28,212,43,48,49,66,50,37,66,222,58,194,72,34,97,166,80,131,104,238,97,59,246,100,204,238,43,18,246,4,24,60,71,31,228,1,154,40,67,63,108,231,137,114,11,255,96,241,95,136,7,54,35,129,19,246,33,54,60,10,18,44,65,79,98,12,18,20,65,75,62,2,89,58,142,104,186,66,139,78,202,18,156,165,12,133,114,5,225,140,83,192,0,61,146,202,44,200,255,104,7,5,101,7,111,192,121,116,12,94,124,236,36,178,19,45,206,2,12,120,64,168,182,198,6,164,44,116,190,234,110,198,194,12,46,144,7,88,229,36,10,165,85,126,50,162,182,230,173,188,10,37,108,128,205,96,162,105,4,180,105,76,76,78,218,224,164,188,8,12,138,147,13,50,101,207,44,161,7,154,230,200,140,97,162,46,161,19,164,144,76,140,161,236,4,148,13,33,39,12,48,193,25,210,108,40,94,98,144,242,206,235,216,236,18,156,193,240,82,180,13,182,128,93,98,160,34,196,3,6,190,136,206,40,107,80,202,5,176,12,208,18,46,45,94,36,2,179,218,0,51,142,225,12,234,144,246,38,139,209,158,36,70,3,192,59,42,226,12,10,43,96,58,137,53,20,46,0,197,231,107,232,197,118,100,141,96,40,132,66,12,146,97,238,7,19,211,3,6,142,132,16,150,235,72,38,136,216,104,47,12,172,75,156,224,45,61,62,198,100,226,33,33,196,139,137,78,36,102,32,129,41,216,43,78,229,1,102,116,1,31,216,161,22,186,13,189,192,96,103,136,145,41,58,255,98,35,60,98,23,182,160,76,240,1,198,108,66,194,194,64,5,172,137,87,22,1,6,36,163,62,140,129,135,240,143,214,234,65,63,238,33,25,238,131,146,254,2,255,142,161,125,136,19,18,32,225,9,63,42,31,116,1,18,228,193,76,128,167,9,145,101,64,80,2,120,208,172,52,140,136,75,204,166,115,106,46,88,76,162,4,107,46,61,48,99,116,22,68,168,204,136,59,21,100,44,180,98,34,163,231,142,168,115,4,91,240,35,195,70,33,27,242,44,88,238,139,206,228,12,18,229,2,197,12,37,63,39,204,66,39,45,250,238,36,195,12,235,182,44,204,172,172,212,188,136,208,172,240,18,154,65,13,205,128,25,152,225,208,226,35,224,16,109,177,2,75,13,3,111,90,40,203,139,94,194,115,74,237,95,5,109,11,37,77,176,132,80,92,98,32,59,196,64,48,158,114,12,33,103,45,182,224,37,44,161,19,164,177,64,172,82,57,6,232,6,2,160,115,46,225,226,134,212,111,110,128,239,122,35,38,32,150,14,49,214,44,61,7,144,254,200,39,142,161,145,126,197,182,0,255,70,183,234,163,94,228,210,214,184,3,65,46,145,66,208,227,66,238,7,217,214,164,185,134,70,34,8,42,97,175,139,246,182,192,65,34,164,22,139,73,129,228,65,23,188,65,24,4,2,50,161,35,39,202,77,157,214,193,70,200,65,30,184,79,69,200,97,106,169,226,132,36,98,73,128,166,22,20,117,2,227,161,50,250,6,18,226,33,31,150,17,19,116,131,142,132,195,30,234,21,18,175,177,39,110,106,27,245,3,109,108,235,152,128,1,209,172,108,47,204,0,195,238,65,106,244,1,24,32,65,54,204,128,55,104,170,29,145,83,139,134,142,65,181,130,38,75,227,2,145,202,111,136,45,4,199,178,103,110,207,36,106,46,88,119,144,126,48,131,142,146,194,200,44,35,63,81,130,8,103,78,235,196,34,59,255,179,61,79,87,209,6,9,7,75,205,38,56,23,40,229,198,60,119,199,63,93,176,234,232,136,205,182,238,239,82,174,105,208,2,114,246,228,10,135,199,88,144,44,85,144,204,30,170,174,117,112,40,229,14,143,56,187,10,118,137,112,66,3,214,67,59,212,70,149,255,163,67,250,134,17,150,67,58,229,102,208,66,144,142,244,142,86,20,43,4,99,200,61,162,133,237,90,80,176,142,167,36,44,131,12,87,224,57,58,47,12,230,183,60,0,54,124,15,139,152,86,99,109,121,235,30,204,103,55,232,161,214,140,225,184,166,105,75,189,148,48,170,35,58,168,109,127,192,160,22,188,54,34,110,128,16,144,103,122,134,109,73,141,33,157,224,161,29,28,66,32,96,70,29,94,52,39,144,47,131,146,111,29,226,225,69,106,65,29,190,1,188,34,245,114,84,192,24,131,166,222,42,21,25,226,65,109,141,1,24,82,37,30,0,96,47,132,33,63,80,5,18,56,225,39,10,203,24,226,84,194,184,132,96,242,131,96,54,85,54,121,45,246,188,81,226,252,101,71,100,115,64,180,72,11,122,67,136,224,241,56,188,40,89,20,33,164,226,212,115,200,198,115,146,162,32,25,70,48,236,232,114,119,80,83,178,179,97,4,37,34,244,102,111,80,239,2,231,106,203,228,68,230,14,82,209,46,112,4,229,243,171,192,160,7,164,142,207,254,53,11,151,208,8,79,126,114,107,244,34,69,175,12,240,60,7,235,218,130,58,85,183,105,132,162,88,194,192,236,132,225,205,204,128,75,66,134,25,66,230,24,182,4,126,254,168,25,10,39,240,76,84,24,254,149,64,75,13,235,56,193,173,82,203,70,251,85,78,198,18,0,150,116,11,86,64,48,86,64,5,212,213,70,95,34,105,72,138,11,1,233,12,96,180,34,88,194,11,247,132,40,224,87,8,199,240,120,188,67,150,99,148,34,108,73,176,98,2,38,48,169,94,2,70,214,38,137,183,224,1,27,37,255,227,96,18,152,160,164,105,103,241,82,65,152,17,217,128,214,107,219,35,59,200,137,67,46,130,160,62,38,131,128,129,23,146,129,29,130,97,23,74,195,69,212,33,130,35,194,6,238,41,101,118,129,23,36,129,23,130,97,29,192,171,28,200,129,101,96,185,103,172,98,191,22,129,16,130,197,48,112,8,53,42,115,71,122,130,35,97,0,154,124,203,24,172,148,96,128,78,62,140,193,18,96,199,101,91,86,183,6,132,30,228,114,154,137,120,50,62,186,101,19,167,162,243,129,194,102,136,166,158,16,176,254,138,163,35,103,194,50,39,12,80,149,148,31,134,216,154,106,45,122,6,51,40,71,134,106,142,4,179,147,216,224,55,24,252,6,45,156,142,143,111,48,12,48,102,4,67,231,167,208,179,70,47,176,233,182,70,110,58,103,36,51,242,37,174,236,116,23,180,96,141,153,40,118,71,235,74,114,171,183,78,13,7,11,178,62,90,215,26,163,39,24,11,24,134,46,210,204,174,54,84,210,236,214,245,38,7,84,208,48,193,18,218,96,176,8,244,36,129,76,50,145,107,178,174,255,208,125,67,86,93,243,87,196,182,35,125,195,32,149,135,7,19,232,236,41,99,2,19,126,99,178,206,244,184,102,20,61,142,80,237,60,135,120,36,35,145,96,135,96,90,118,50,36,67,31,216,69,128,186,227,180,101,212,180,41,68,126,10,67,76,49,227,72,188,118,231,218,163,99,100,228,130,214,65,24,118,161,22,144,68,161,121,1,106,213,161,51,97,57,58,50,40,183,55,226,160,14,106,23,132,161,28,82,70,23,118,166,93,136,145,35,116,219,35,12,3,51,172,17,210,124,2,135,240,162,38,248,21,85,45,33,30,196,4,85,0,131,94,106,67,188,145,120,55,172,209,197,174,49,85,244,195,12,116,3,31,226,84,87,81,163,81,131,193,187,185,140,75,34,1,195,44,232,108,128,242,9,205,0,85,79,227,120,217,204,32,147,2,18,140,141,93,12,64,78,210,35,149,152,106,216,14,18,47,159,198,166,75,174,59,180,107,142,210,131,237,120,238,192,13,69,43,238,134,107,108,160,80,58,229,32,225,83,120,83,78,78,74,244,39,143,198,169,191,108,40,34,91,235,26,255,173,111,72,84,204,40,11,146,187,10,114,172,155,38,23,121,64,56,26,205,112,72,214,78,234,84,46,84,210,4,20,114,154,166,95,95,34,38,236,90,96,233,172,150,190,67,59,142,231,120,250,179,115,36,193,95,233,72,148,1,54,18,218,192,59,18,196,59,118,114,52,132,226,209,38,107,85,152,188,60,162,82,111,60,114,40,132,1,208,76,212,119,122,120,112,49,12,54,157,105,50,12,58,58,136,171,67,228,124,160,112,182,59,152,17,66,168,77,77,167,22,92,12,104,73,131,27,12,50,40,24,162,187,72,106,225,208,21,161,22,122,184,22,152,98,17,188,15,73,14,29,210,17,149,23,120,225,69,206,20,252,26,221,72,140,49,253,160,226,69,101,45,65,108,199,18,160,6,31,56,133,1,87,194,24,32,145,147,211,103,173,33,109,245,172,236,9,117,163,101,129,193,25,66,123,129,242,225,25,12,7,232,122,2,106,42,101,112,109,64,24,186,91,212,35,3,54,220,91,54,124,103,112,45,227,11,163,165,54,182,162,82,132,138,216,66,135,108,188,180,193,115,98,195,237,255,57,39,166,154,109,20,230,18,136,205,141,239,121,106,243,211,151,233,71,34,10,69,90,177,142,114,141,176,145,215,149,207,210,98,207,202,240,10,217,172,63,181,238,202,186,76,38,197,250,139,154,38,229,32,129,7,34,129,13,118,199,186,137,69,50,2,235,24,250,206,209,172,236,239,140,185,122,129,210,237,250,253,237,168,19,254,214,162,111,104,169,15,235,55,41,45,65,40,74,188,212,222,206,115,48,99,126,189,99,202,107,227,55,28,77,100,15,175,15,61,47,51,148,131,9,171,151,177,34,59,165,20,205,147,127,35,24,56,33,113,70,67,70,19,220,192,101,52,65,80,123,67,194,20,127,34,100,80,152,139,216,102,59,134,52,132,93,130,39,210,145,62,73,144,30,106,237,25,189,10,193,208,105,193,21,15,253,208,163,158,23,20,194,78,96,155,185,222,177,19,165,19,205,132,161,104,34,193,187,95,67,36,14,68,40,153,1,170,26,233,56,110,88,89,244,132,96,112,56,53,224,97,187,164,19,24,220,243,255,252,234,205,40,174,244,142,65,195,80,149,96,204,32,30,42,255,197,24,132,99,194,22,177,101,171,206,5,1,163,120,174,204,53,13,215,12,22,65,220,237,172,5,89,166,80,46,215,142,205,134,216,20,141,242,239,231,115,136,173,39,128,100,90,136,45,231,236,56,169,220,216,80,192,128,168,65,28,204,80,114,206,78,34,45,202,38,64,123,185,70,145,163,25,232,8,235,0,111,52,244,61,127,167,78,237,96,162,191,245,12,40,229,143,12,59,103,176,251,123,151,133,188,171,8,212,237,242,183,12,221,142,13,96,66,249,187,106,208,146,138,17,96,165,109,64,86,44,48,62,40,181,223,108,72,28,235,208,55,226,177,174,240,200,208,115,96,162,149,150,60,12,54,107,59,110,96,17,40,39,198,123,31,199,36,91,179,131,225,177,44,35,172,225,204,57,234,167,206,193,84,255,185,180,231,1,66,75,12,21,90,96,108,1,179,5,0,128,24,0,14,52,84,8,96,81,173,69,139,20,85,188,104,49,227,34,66,139,192,64,4,0,99,81,33,69,133,46,46,218,162,40,12,161,48,90,88,134,89,196,240,163,76,138,22,77,182,180,20,9,64,24,255,27,144,46,65,138,116,6,76,36,72,205,22,69,178,193,19,88,190,125,250,44,25,139,7,236,216,37,48,102,84,216,64,118,15,223,177,96,150,238,117,61,6,201,204,150,99,198,142,29,3,22,149,236,177,172,240,142,225,139,183,214,24,62,24,200,186,102,197,7,201,108,188,123,96,108,236,12,99,108,42,78,51,92,163,94,10,118,201,76,24,0,6,20,69,138,180,24,6,152,197,0,206,92,138,164,2,128,13,143,0,204,64,154,124,6,36,140,48,83,65,6,51,123,79,33,48,99,10,109,68,186,68,121,180,194,72,138,41,135,129,161,48,140,153,51,103,116,7,53,67,53,40,152,160,188,169,238,14,27,28,82,39,99,102,132,177,185,148,24,250,107,170,208,129,195,54,147,120,119,98,48,109,44,245,180,148,29,58,239,75,150,207,152,161,109,190,252,121,222,216,207,179,161,189,251,12,80,72,242,47,159,161,223,179,190,249,48,42,248,199,136,17,70,111,1,128,1,137,37,160,153,33,137,124,187,1,69,91,24,144,57,232,223,127,176,189,86,223,37,91,189,247,90,27,144,255,41,136,91,24,98,220,182,194,104,163,145,71,219,37,152,92,34,140,118,12,94,210,6,116,244,245,70,92,128,6,196,0,67,141,32,49,100,128,10,14,225,22,226,1,48,208,24,0,12,42,12,84,227,22,90,104,97,36,101,32,173,144,163,76,78,62,9,101,148,82,70,73,83,45,138,104,65,209,145,6,141,230,23,129,66,29,21,140,62,250,128,1,70,136,102,196,163,79,48,248,156,86,150,49,192,32,19,12,48,92,97,181,38,24,249,88,2,12,62,247,28,115,134,37,204,196,19,207,159,247,0,99,73,92,100,221,19,76,155,247,96,119,143,49,78,249,116,140,37,242,88,194,21,24,91,153,97,137,48,96,120,183,21,24,248,16,74,230,37,10,129,81,26,0,83,217,32,218,71,55,224,6,134,48,151,32,197,217,109,189,41,100,222,166,184,5,19,90,103,164,114,102,131,25,180,130,214,26,24,184,129,244,155,80,241,241,70,28,111,54,236,151,94,27,191,157,135,157,34,109,244,148,24,36,200,76,85,236,110,164,62,102,198,122,64,45,168,29,169,244,209,246,24,121,228,255,65,107,95,98,12,46,40,31,85,195,201,167,32,133,10,222,7,175,13,52,254,7,195,135,42,156,129,79,51,97,72,178,219,121,26,202,55,110,36,96,172,26,198,189,33,10,3,73,139,61,189,118,24,116,56,137,119,25,108,0,222,134,47,128,227,85,12,20,38,221,194,251,90,24,16,42,184,224,112,53,206,152,163,1,0,100,150,178,10,6,52,137,91,203,42,192,160,5,65,70,210,188,8,12,1,64,180,243,148,83,246,236,115,208,10,141,86,19,69,20,129,177,200,13,146,0,0,6,50,139,253,23,6,129,200,216,137,207,202,96,96,130,73,60,151,88,130,79,87,150,236,85,150,25,200,224,149,87,62,193,152,225,21,85,138,0,231,153,49,136,70,234,221,214,192,236,137,150,49,106,166,189,83,183,84,53,19,207,157,180,193,112,201,61,97,116,245,90,156,224,117,205,9,12,224,121,100,64,36,184,217,112,207,25,195,10,105,3,12,138,225,6,3,15,125,5,8,82,229,142,231,182,89,15,173,13,171,216,13,55,40,212,237,175,203,102,182,236,25,168,86,102,198,13,138,255,41,54,238,102,194,237,22,96,80,67,197,7,110,175,150,133,213,103,36,55,36,219,167,101,221,250,6,92,111,137,133,49,46,181,240,89,71,47,122,192,71,162,97,183,151,97,7,148,121,232,41,182,46,111,227,214,86,35,128,52,38,76,218,49,37,90,146,59,122,240,194,187,197,140,43,208,184,130,124,20,130,11,221,101,211,186,168,225,13,97,172,42,254,143,234,2,229,32,251,60,166,97,228,138,207,187,134,67,31,221,4,233,70,67,51,64,248,98,48,35,144,12,77,33,12,17,146,65,10,130,164,11,226,38,0,41,3,154,208,0,224,193,15,70,169,103,33,169,5,71,32,81,139,93,44,226,72,44,169,220,109,182,160,130,211,185,198,53,222,145,199,100,128,163,5,48,0,227,18,249,56,134,60,34,209,12,99,48,67,78,123,210,83,86,188,131,149,102,228,229,30,156,208,130,133,44,1,156,197,153,129,25,82,105,212,169,162,195,6,243,116,171,13,84,49,70,51,196,3,3,72,24,3,13,199,192,14,36,168,104,48,76,145,199,18,108,16,22,99,104,53,152,214,68,13,255,40,155,25,154,200,144,178,144,205,188,170,53,72,121,157,95,90,179,170,97,153,71,142,120,212,12,153,42,103,200,225,44,235,128,138,220,73,80,22,153,158,228,5,167,86,251,209,86,242,214,115,158,236,124,11,40,4,138,36,118,180,135,29,18,165,17,61,216,210,222,183,214,39,29,144,153,97,17,209,35,23,200,44,35,6,48,252,71,127,248,34,213,158,238,209,140,193,60,6,94,164,129,216,64,224,55,26,243,156,8,147,175,129,88,196,164,115,47,241,197,96,62,188,225,150,42,223,181,73,73,158,129,149,186,129,140,203,174,249,64,204,253,72,72,59,146,32,12,84,198,164,153,109,161,70,90,170,194,176,70,168,16,160,133,208,73,235,20,33,0,182,48,17,139,96,233,104,48,97,204,204,6,7,197,201,168,0,105,47,148,207,86,64,146,15,100,192,224,30,240,104,35,15,83,132,182,99,32,163,39,122,178,135,61,226,129,15,121,224,163,78,193,184,71,181,154,129,143,80,25,200,24,200,40,163,235,54,227,151,0,65,209,12,104,232,203,118,196,102,137,94,153,97,89,5,255,58,134,236,8,100,131,75,148,52,87,196,18,142,202,0,176,170,161,153,97,88,14,52,192,235,96,112,0,191,220,244,71,16,129,193,233,52,211,199,81,29,236,73,54,184,65,147,96,247,72,215,81,101,145,182,43,86,175,2,244,174,227,249,165,56,199,34,142,187,204,51,149,224,112,146,55,172,28,206,183,60,70,175,252,144,135,52,147,17,229,126,164,71,175,100,101,175,55,236,218,36,189,206,147,48,0,161,65,100,49,176,76,166,164,99,9,100,120,162,126,245,179,140,22,222,7,195,24,152,65,42,208,57,141,91,46,209,209,173,245,107,107,151,24,141,24,36,145,87,237,173,15,128,188,100,230,52,229,19,160,0,205,46,65,146,19,205,127,156,196,144,24,220,224,154,6,8,167,104,44,56,51,42,104,240,72,153,89,153,59,63,216,78,158,21,85,133,22,137,196,10,45,130,144,31,9,139,70,48,176,129,37,12,116,137,213,98,226,24,48,144,4,24,134,68,170,60,73,194,107,97,56,134,61,252,212,45,78,108,42,42,133,242,10,48,154,145,140,72,60,133,13,129,81,71,255,129,132,49,82,238,216,128,43,184,186,4,39,96,211,151,30,112,53,49,6,24,156,98,250,4,156,54,116,11,6,150,137,169,13,48,193,6,144,34,82,87,198,41,45,68,252,130,148,115,166,106,104,174,59,167,141,138,27,172,1,219,14,34,178,11,150,66,12,64,21,217,189,52,106,55,24,142,135,99,116,213,128,5,104,172,108,251,176,34,93,87,28,249,248,110,89,115,212,214,118,226,69,47,233,192,103,147,239,66,86,212,136,195,173,28,223,135,92,232,89,23,131,202,35,75,0,137,97,175,252,141,68,22,141,57,177,196,160,230,30,145,200,209,105,77,116,153,72,156,8,98,200,40,102,148,111,51,100,190,234,239,199,12,170,166,102,179,183,136,174,194,75,40,150,137,218,141,84,22,51,214,74,240,70,195,114,25,72,130,116,128,153,133,40,6,71,162,243,189,106,155,91,153,120,48,183,33,84,167,76,84,32,17,69,88,100,34,181,240,45,146,130,52,25,192,85,238,6,138,184,142,176,132,5,131,163,140,134,84,93,115,74,164,162,107,6,123,196,7,36,129,147,20,51,238,255,129,12,102,176,209,30,131,178,16,62,46,33,234,36,235,230,189,238,218,9,85,111,128,20,51,116,162,193,54,104,131,13,84,176,155,101,189,106,89,43,125,150,136,121,189,177,71,246,49,40,176,238,163,30,251,82,57,88,193,218,213,77,69,240,162,107,100,236,226,246,133,76,30,246,75,236,86,26,181,205,56,114,165,96,232,65,35,121,144,183,108,139,150,218,49,242,240,236,14,168,155,170,106,207,119,138,49,107,187,192,197,204,246,240,24,92,4,194,42,105,216,3,49,160,8,208,50,143,1,79,253,34,129,62,236,237,47,6,91,64,131,36,196,176,229,18,89,89,58,137,186,196,169,23,162,130,57,211,8,148,59,86,215,192,108,80,240,131,255,7,64,228,113,247,43,179,87,50,178,78,6,52,32,135,12,24,28,232,205,27,109,92,52,41,19,141,143,152,84,163,33,193,86,32,5,153,89,157,159,180,231,219,250,44,36,188,40,90,24,20,177,11,67,223,6,55,171,34,217,254,138,235,23,26,29,178,70,142,3,206,86,112,226,69,123,228,67,31,205,16,214,102,24,96,131,255,137,78,212,177,142,58,110,83,59,1,12,203,76,133,7,0,215,206,111,144,34,187,72,240,0,193,203,62,88,113,71,179,170,102,43,198,217,189,138,117,177,13,240,42,109,213,157,214,174,187,28,175,177,83,108,186,35,197,213,200,110,42,210,155,173,191,62,166,59,215,125,65,177,135,189,253,209,222,12,7,242,193,153,76,235,62,204,107,223,188,75,243,65,9,3,184,117,99,110,235,237,164,241,188,139,222,180,250,68,149,239,92,143,68,198,123,141,37,94,89,30,250,132,242,124,39,162,86,40,67,137,147,253,173,224,6,31,162,81,135,171,3,177,242,156,33,153,248,10,0,252,174,119,45,177,179,40,106,170,245,16,212,2,84,48,208,142,185,172,144,249,241,177,14,120,159,27,135,166,130,246,156,209,55,107,20,36,8,206,140,70,32,105,185,147,97,75,51,58,143,147,102,53,215,57,8,221,185,133,48,164,144,34,42,68,218,68,176,148,109,108,251,148,170,155,137,251,74,59,156,48,126,49,21,150,51,56,156,240,28,150,128,9,167,246,77,21,36,117,68,33,42,54,112,12,255,241,208,6,152,128,12,192,176,83,134,199,95,198,49,21,195,211,84,185,163,119,195,227,72,86,183,63,149,195,0,35,216,108,131,215,58,198,214,27,131,135,108,212,54,108,72,177,118,116,199,37,198,214,37,139,134,96,72,183,42,150,135,118,133,247,72,221,54,109,189,50,60,140,164,57,194,97,59,7,148,60,233,145,85,55,132,60,186,193,132,224,118,125,205,68,42,88,147,15,152,64,29,234,211,19,212,34,21,153,82,70,148,133,19,148,210,9,224,65,28,248,1,45,10,247,27,212,243,26,11,146,24,174,18,124,212,211,17,127,33,50,199,146,73,103,160,8,240,178,113,55,48,75,55,176,5,16,148,61,151,145,31,187,212,27,119,36,50,30,199,32,30,150,59,170,196,111,242,3,35,38,71,87,189,241,57,46,19,34,11,84,84,145,184,77,77,130,77,140,1,76,42,48,51,226,84,51,227,148,88,65,195,103,83,130,37,188,101,20,65,103,18,8,97,47,46,36,57,246,146,83,203,210,71,203,134,96,43,85,119,248,208,9,58,84,89,164,1,56,43,96,21,146,19,6,255,194,192,9,198,224,40,65,113,15,249,96,41,141,130,15,203,66,133,178,134,29,25,101,59,127,209,23,29,230,132,125,4,110,131,103,84,146,19,119,59,81,92,204,22,20,144,199,138,145,116,48,177,179,44,47,133,96,110,199,108,253,167,131,176,214,97,49,128,118,208,6,43,206,182,19,29,198,138,64,8,6,60,240,72,192,193,107,195,209,107,143,39,20,6,5,28,99,69,38,188,161,57,218,18,85,33,22,42,90,244,95,195,241,12,201,128,12,30,99,134,35,246,28,141,117,12,205,112,26,96,39,21,167,17,12,193,192,9,136,225,25,148,133,46,250,193,111,131,69,42,21,115,46,231,162,111,6,227,44,196,17,31,67,225,32,218,51,45,26,18,126,118,72,112,50,224,146,172,151,61,35,41,147,187,49,48,156,101,99,150,129,9,197,132,53,82,214,121,81,147,59,224,166,59,196,241,70,45,211,50,23,166,102,225,243,77,11,49,57,74,153,137,227,36,91,227,132,65,70,18,19,238,247,36,91,176,8,42,116,17,96,80,8,133,86,11,188,176,66,45,4,107,223,84,119,255,16,132,20,199,37,57,103,96,12,228,216,23,91,200,29,205,16,9,199,208,6,208,102,73,74,132,15,204,113,107,206,128,29,199,96,128,248,96,15,204,49,43,95,100,9,205,32,12,6,48,69,251,195,6,1,194,69,77,133,59,200,66,143,176,216,71,64,193,24,149,179,127,52,136,20,202,34,96,172,24,143,40,136,118,157,121,131,197,198,108,150,135,108,92,178,42,99,233,153,121,3,107,55,228,142,103,151,30,228,241,30,1,179,72,122,163,30,72,8,144,6,163,30,1,210,37,159,212,45,187,129,19,42,133,29,189,194,6,199,5,30,224,65,45,195,185,53,222,209,19,112,115,54,216,65,156,14,87,145,135,113,45,215,163,111,196,217,34,245,243,48,221,146,70,248,182,75,171,180,62,31,39,31,109,240,31,239,163,90,27,167,49,238,118,99,41,153,74,131,72,34,41,249,24,99,5,25,38,50,86,48,194,30,35,99,64,156,147,25,110,166,16,44,147,159,42,115,90,67,195,125,196,69,35,14,180,113,79,73,78,234,199,126,84,169,51,66,179,2,233,180,50,49,96,52,255,21,49,18,20,193,17,29,1,150,92,105,138,72,183,82,187,81,92,247,192,12,198,240,133,205,0,107,205,240,155,178,22,20,45,98,30,144,32,59,59,197,113,199,37,46,137,118,9,154,99,12,200,6,0,93,1,107,190,40,12,149,179,41,32,241,144,100,98,150,45,72,119,54,86,131,171,82,130,195,131,9,211,120,48,71,10,82,133,231,108,200,214,97,238,8,43,204,40,96,58,200,118,201,246,118,54,136,131,9,102,3,107,55,122,40,56,109,78,58,109,238,1,45,186,49,132,212,17,28,190,225,27,148,196,59,55,36,76,102,48,48,247,49,48,18,115,6,123,98,22,23,233,29,67,73,31,66,209,52,152,240,19,32,121,26,226,161,32,255,70,73,180,65,21,56,113,31,216,169,69,250,214,76,0,244,73,12,210,6,204,211,76,223,73,27,144,16,6,222,71,112,46,185,76,31,41,50,15,34,20,133,101,168,14,114,95,21,227,85,243,146,61,100,22,31,176,129,44,147,97,155,65,97,137,51,226,50,49,81,91,228,7,18,58,82,91,48,0,115,170,149,137,21,180,77,255,4,122,36,72,50,149,187,202,18,68,18,0,120,150,25,196,133,36,252,20,79,192,133,149,133,214,17,18,177,172,83,65,30,225,179,42,222,102,58,56,138,97,60,65,41,150,211,53,188,193,95,198,182,57,211,214,73,183,33,163,161,97,9,249,16,32,156,128,29,241,96,9,6,112,6,156,0,30,199,160,151,0,208,12,204,128,9,192,208,6,42,16,9,179,232,142,227,216,138,223,152,96,250,83,92,152,176,165,150,217,71,51,216,120,73,218,108,227,216,140,197,86,108,4,59,26,88,131,9,113,151,108,129,39,120,39,120,164,0,200,118,174,198,34,83,117,46,221,246,27,94,117,72,68,152,104,58,200,46,125,17,22,199,195,30,90,37,156,128,26,90,1,178,8,54,224,92,138,104,48,97,16,12,13,194,73,235,81,43,2,67,46,14,151,24,144,154,44,36,66,76,11,98,123,61,246,168,41,201,27,97,176,2,113,70,158,58,105,54,147,33,50,137,42,99,205,4,159,157,55,30,152,32,12,242,177,147,242,179,33,35,246,74,232,6,47,41,39,65,42,163,35,51,106,9,255,163,225,50,217,84,57,53,242,77,48,103,47,219,68,92,114,70,115,70,114,16,188,42,183,133,0,6,72,114,37,227,68,18,2,161,8,91,64,8,71,82,52,89,50,104,89,18,6,91,192,9,204,160,174,151,137,165,198,102,107,155,129,29,139,155,144,201,182,63,239,210,84,200,150,109,140,219,9,163,1,9,126,193,0,48,192,12,150,195,92,95,232,20,247,16,83,236,58,40,144,99,41,139,121,15,152,139,20,49,32,44,163,119,27,185,150,96,110,119,182,36,72,92,7,227,23,28,24,6,30,131,85,253,167,120,84,245,81,63,152,184,155,97,84,151,64,10,200,64,28,134,151,108,207,6,109,145,11,82,174,198,188,33,181,25,55,20,83,174,35,123,193,17,58,141,167,72,195,145,110,204,120,99,155,225,132,161,213,106,204,139,85,237,121,30,8,84,31,143,177,187,185,211,143,198,241,99,218,23,48,107,36,21,231,177,34,137,202,136,35,198,32,63,118,25,35,54,190,135,17,20,194,240,93,9,115,0,27,71,42,193,48,54,76,11,90,232,233,42,31,57,28,62,11,90,255,38,18,133,230,114,164,72,88,28,53,150,44,30,38,65,3,97,0,59,3,65,147,19,3,126,194,182,61,101,84,105,219,90,197,245,25,14,148,25,26,100,65,5,1,183,7,33,149,44,156,65,197,138,36,251,84,8,71,114,16,37,17,104,38,209,17,90,144,18,168,2,129,146,16,109,10,91,95,39,194,129,208,161,185,150,67,30,156,96,15,206,224,46,125,97,57,205,118,48,160,87,154,86,183,2,204,112,27,209,113,92,74,84,23,164,226,139,144,99,6,205,96,92,124,129,54,134,55,28,213,56,120,63,217,108,6,80,154,53,162,176,201,235,108,31,229,141,32,37,177,218,230,153,2,230,106,197,198,196,189,139,188,111,103,135,52,136,155,169,57,120,255,247,127,27,214,110,161,74,21,160,231,109,76,56,59,190,113,189,144,68,38,222,214,107,160,215,121,70,168,61,228,209,17,238,230,45,49,150,92,177,211,131,137,124,95,179,3,27,193,164,89,90,59,114,67,137,44,41,246,27,215,17,12,206,128,12,205,225,172,247,192,100,165,169,90,167,22,88,243,176,85,64,25,90,255,183,183,62,1,2,27,190,49,87,147,113,34,57,169,168,146,39,121,29,166,189,189,129,27,226,135,114,20,196,52,172,107,6,49,176,160,175,181,63,43,211,97,205,160,93,29,166,24,1,186,77,70,50,36,51,35,25,114,75,103,48,28,3,43,65,8,70,178,183,243,196,18,7,145,149,70,99,161,139,176,165,174,227,64,157,121,165,213,186,127,149,121,153,38,85,81,80,52,122,113,55,109,210,70,38,187,91,57,1,16,12,189,114,9,198,160,5,205,160,56,122,212,12,249,0,145,49,101,9,109,65,69,8,1,69,252,133,62,234,120,120,198,102,141,122,140,165,122,108,84,209,246,164,20,235,199,118,28,177,183,107,187,135,20,83,111,252,108,86,218,71,172,27,194,29,22,76,3,155,109,31,91,119,25,42,144,82,117,59,178,227,188,214,22,53,148,231,120,17,92,200,165,186,30,88,213,46,243,137,59,71,168,125,71,26,6,61,160,190,69,11,35,161,165,63,189,81,86,101,117,99,232,11,35,168,42,63,110,37,49,51,171,27,200,32,140,152,50,28,226,25,6,200,144,34,255,83,195,74,80,253,135,159,33,213,135,200,101,49,82,180,87,195,143,76,168,214,53,102,166,20,196,159,11,225,83,56,133,182,164,50,35,134,231,83,237,216,164,70,213,23,220,214,164,63,216,182,230,84,103,52,204,171,70,130,37,45,33,183,16,138,16,118,187,66,97,137,12,253,154,142,198,22,119,44,29,194,33,197,210,124,236,83,219,119,153,210,236,50,8,134,142,53,2,95,203,228,117,254,134,39,252,194,174,102,225,38,216,33,106,102,17,12,97,192,12,22,162,24,137,209,84,137,199,188,148,187,131,215,88,199,106,140,116,178,203,153,228,24,120,249,156,175,201,230,131,158,183,85,133,103,141,39,136,116,138,133,45,49,244,152,163,119,6,206,2,132,177,38,199,30,54,25,154,99,205,142,36,200,38,57,60,220,22,130,83,173,125,74,173,189,201,99,48,253,8,20,97,38,90,64,221,143,77,187,212,250,115,200,160,113,99,30,6,128,43,91,102,83,141,136,99,5,146,174,65,192,160,225,172,9,105,170,136,129,142,154,50,53,63,13,33,81,19,133,102,218,157,54,230,158,255,75,189,85,116,149,59,184,185,212,143,36,90,39,67,84,70,21,67,4,98,6,61,0,9,228,5,30,142,115,141,47,131,20,239,172,131,201,29,83,175,242,72,104,27,113,66,130,137,54,39,78,141,205,171,49,80,206,188,106,161,28,230,83,14,132,131,197,85,108,52,146,96,188,109,3,251,71,150,252,163,227,211,152,110,223,52,56,205,96,62,44,154,24,10,249,92,204,32,15,250,240,105,103,144,40,249,16,140,250,96,81,44,42,44,113,218,40,110,19,208,192,208,161,55,68,143,81,106,209,8,214,142,125,36,165,183,177,131,127,113,141,56,142,164,155,211,187,234,136,176,203,18,96,246,72,226,135,247,215,93,113,163,102,97,32,184,180,41,199,117,12,95,218,119,230,193,110,55,224,132,179,67,87,227,141,155,88,85,204,41,214,207,74,13,148,67,221,32,9,100,232,180,147,203,247,229,121,136,28,142,34,13,128,76,59,200,157,7,64,122,116,6,87,59,159,245,93,204,198,251,12,201,39,9,249,208,67,24,153,61,50,123,106,103,32,9,213,39,50,177,158,169,186,27,213,255,94,21,136,138,225,195,155,183,136,115,165,44,77,203,97,227,237,58,92,228,64,174,246,77,104,236,121,219,202,204,75,85,95,32,133,97,230,8,43,1,118,182,99,25,59,43,125,182,0,106,65,178,69,16,223,108,216,44,108,117,69,103,131,123,220,227,9,230,35,225,227,83,230,24,72,104,124,182,239,172,199,150,103,9,230,58,169,14,135,26,202,184,25,205,192,68,249,64,106,8,120,156,247,48,15,98,228,139,113,201,12,132,25,9,141,226,12,112,81,186,178,125,26,149,211,9,237,166,240,129,125,6,77,234,108,126,109,219,177,235,58,132,215,118,112,108,187,126,81,165,27,173,108,62,216,120,128,14,107,192,49,109,76,40,156,185,228,20,92,126,15,246,176,22,199,117,242,142,34,54,193,96,86,216,105,73,38,38,85,110,253,97,148,222,110,218,231,214,229,13,28,14,226,113,68,139,222,131,28,223,48,50,200,155,71,233,12,31,90,140,72,108,186,193,95,136,65,133,120,90,76,165,76,30,241,130,9,185,199,60,199,144,15,85,11,159,204,19,9,99,147,64,218,65,133,255,146,7,136,148,254,157,99,38,125,43,123,166,159,245,147,82,91,233,135,12,148,82,229,64,113,234,43,146,17,247,53,142,220,108,252,106,197,5,187,51,2,177,205,86,92,232,88,238,253,138,57,55,208,18,217,46,75,234,24,177,106,188,25,62,222,227,245,229,35,61,110,84,88,199,219,33,92,35,183,97,58,53,178,185,213,216,140,158,11,105,158,193,9,102,129,58,158,1,30,142,98,173,101,33,106,55,208,208,204,192,12,0,119,15,250,32,15,205,0,15,111,17,129,156,192,161,180,33,106,206,58,118,205,40,230,124,47,188,177,222,209,145,235,199,100,226,199,99,46,25,126,161,5,15,143,165,14,47,176,138,244,73,145,119,150,34,10,250,167,113,93,96,160,38,150,38,68,247,32,15,199,208,161,159,97,109,212,134,200,71,74,185,146,164,168,76,168,198,247,5,90,53,118,61,65,17,86,97,102,190,102,53,170,38,9,45,199,242,45,15,238,214,200,242,95,34,147,32,95,141,234,249,128,144,249,208,9,193,0,16,152,206,96,186,116,230,12,24,48,97,34,25,60,120,240,255,18,24,51,103,34,34,180,1,38,82,24,134,199,48,134,185,20,198,34,164,51,145,18,134,241,184,40,228,201,144,9,13,110,52,131,241,76,65,146,30,79,98,84,105,227,140,141,152,43,109,84,180,1,224,0,24,75,16,143,241,192,120,201,140,129,24,49,108,218,128,177,179,41,140,27,0,118,50,101,106,160,226,141,157,86,177,78,181,113,195,106,83,3,96,195,116,109,138,117,43,86,48,55,154,42,85,107,35,134,129,168,93,191,170,109,122,0,134,82,24,119,195,50,205,171,118,111,83,183,79,153,158,141,209,195,140,13,54,55,207,120,52,115,227,210,189,48,194,44,221,235,4,241,210,49,75,150,32,1,179,132,236,30,190,99,156,143,129,177,215,44,94,179,117,199,240,89,50,246,240,94,188,75,150,98,179,1,35,17,39,215,48,125,1,119,165,10,88,37,152,174,141,137,2,31,219,116,236,216,180,9,121,35,191,125,251,6,240,27,91,33,218,62,28,230,240,196,180,59,205,4,227,100,6,0,0,75,103,32,33,12,6,204,152,249,123,192,30,30,11,22,155,96,72,235,110,39,23,94,60,8,6,83,66,149,30,111,96,20,89,59,100,36,51,32,137,77,192,72,10,242,79,36,249,48,82,228,140,69,90,202,201,35,76,204,0,240,32,198,226,171,13,35,155,12,50,176,32,100,144,113,232,18,100,130,105,227,66,255,194,104,195,35,73,92,98,72,146,11,23,195,4,192,240,92,90,72,194,142,98,34,9,39,139,144,145,105,49,134,44,162,144,71,250,172,51,209,163,138,48,124,142,36,233,246,91,255,12,35,171,166,146,170,147,177,12,148,8,176,188,108,104,0,6,171,172,178,171,201,182,156,162,107,39,21,200,10,11,46,46,109,96,96,167,173,166,218,13,46,24,24,128,170,170,170,190,132,107,39,169,192,138,1,75,60,233,82,10,47,190,200,178,225,47,192,252,138,13,167,183,204,192,12,159,123,140,177,132,19,72,216,64,204,40,73,206,192,7,209,120,142,49,227,18,96,86,203,12,12,54,144,185,132,141,72,120,186,228,18,24,46,141,205,168,177,174,170,114,167,220,212,82,43,173,182,160,186,137,166,157,128,187,13,140,188,108,117,174,214,226,110,101,149,43,91,195,192,138,72,34,33,178,21,184,197,112,66,174,216,220,112,130,239,12,24,206,16,230,82,72,194,168,22,161,48,22,65,8,12,97,32,137,228,91,143,56,154,17,92,4,131,146,237,50,111,47,41,80,66,144,212,245,22,187,10,19,74,113,167,144,118,138,225,56,36,143,179,161,160,150,148,93,242,165,8,153,74,235,162,150,36,146,209,160,133,122,156,143,161,136,52,108,99,161,142,212,125,41,197,81,197,45,255,216,163,81,19,130,129,34,132,28,35,201,32,149,90,114,48,190,141,108,96,228,18,49,108,136,232,56,145,51,140,14,171,141,189,139,65,42,124,84,110,6,167,136,238,164,138,79,50,119,58,243,205,167,218,50,107,204,189,156,2,235,79,222,188,234,83,171,47,161,170,146,46,60,157,226,203,205,188,244,186,179,202,61,255,172,82,43,193,120,171,232,48,149,49,17,230,190,54,206,96,19,6,75,242,177,193,18,204,238,65,6,24,123,44,97,195,163,102,130,1,67,221,187,41,186,10,215,90,129,171,173,162,228,184,106,110,227,222,244,245,91,77,179,158,18,214,173,180,154,34,142,216,174,116,29,107,88,175,5,79,117,71,90,107,219,182,182,75,142,60,168,162,72,94,132,1,128,141,177,253,216,36,136,132,97,241,91,117,11,4,119,73,51,52,191,52,189,123,32,129,196,146,54,204,136,125,237,134,53,95,76,185,143,143,91,146,63,76,72,130,225,70,199,13,114,54,173,141,198,90,172,225,226,27,186,1,225,255,254,133,137,33,131,87,230,209,162,2,19,146,240,164,150,30,186,255,16,239,75,182,112,208,190,20,37,201,7,25,250,26,90,233,184,18,225,15,195,18,124,46,137,33,36,76,166,79,235,95,170,186,146,104,191,63,153,77,41,0,128,217,1,152,18,3,55,117,69,105,120,122,147,151,144,22,157,38,49,0,47,102,65,19,111,160,226,149,178,24,48,87,103,177,160,212,182,34,44,44,221,41,44,80,249,10,210,116,246,148,54,57,237,75,110,185,138,254,62,103,43,3,152,225,69,205,240,144,108,192,128,140,216,37,42,18,201,88,91,80,142,193,12,163,88,194,6,60,168,206,229,126,165,31,226,76,165,89,70,220,27,229,150,72,149,231,60,39,57,169,2,14,225,26,23,156,231,52,39,77,82,67,33,83,152,163,53,158,48,43,57,89,20,146,191,42,66,161,152,224,8,33,245,249,15,174,178,181,24,0,1,232,118,15,49,70,51,216,198,26,213,60,230,30,63,186,161,81,182,245,177,11,41,145,66,73,196,17,78,160,18,19,177,225,228,122,42,90,220,240,206,48,61,154,52,143,33,50,17,18,246,10,182,48,151,68,239,121,20,42,216,250,172,255,211,146,145,208,47,31,151,16,70,62,142,33,143,124,132,71,115,97,16,3,24,148,34,44,181,140,69,5,152,24,101,36,238,113,202,75,45,10,42,217,1,80,24,12,240,75,176,236,230,128,124,17,140,217,6,227,52,4,178,5,77,129,202,83,89,238,228,166,43,133,229,103,192,12,11,0,198,132,37,56,93,112,48,44,100,139,96,254,18,22,87,169,16,133,77,227,11,93,70,216,155,169,220,132,55,8,169,18,174,96,96,12,102,176,198,18,112,187,199,62,246,81,158,123,152,102,50,193,184,135,16,141,194,131,40,218,68,95,20,172,85,210,46,161,166,100,121,196,111,204,201,34,85,132,165,28,47,14,171,161,27,107,232,78,180,224,69,116,222,138,138,183,209,151,202,158,115,19,226,224,135,146,177,35,86,184,240,19,41,147,126,107,141,19,10,144,108,216,6,9,204,152,161,19,205,128,68,39,56,3,154,76,177,33,30,246,176,199,37,32,97,12,99,20,40,119,34,89,8,77,46,98,131,69,52,239,72,148,83,206,115,218,208,185,200,97,228,131,61,240,143,242,244,198,163,255,134,168,4,100,10,227,209,70,170,26,137,44,182,111,17,247,153,86,36,52,34,12,97,132,65,31,248,56,131,36,224,129,12,208,232,35,24,251,2,6,247,18,82,16,24,72,194,12,236,139,1,50,48,1,87,124,4,67,31,251,56,70,60,34,1,3,21,20,232,140,41,203,141,82,182,249,204,164,56,37,75,118,249,211,47,229,130,165,95,42,19,47,90,177,87,86,148,226,38,203,146,233,77,224,52,128,53,229,98,149,183,96,201,154,122,137,90,116,24,56,66,10,194,12,104,56,129,153,171,2,3,219,55,41,179,47,76,9,85,90,26,195,145,216,25,10,51,246,56,198,128,140,113,187,91,218,67,61,171,97,70,93,57,113,184,220,24,71,112,91,96,97,170,136,137,44,158,48,53,138,208,57,30,87,134,245,197,193,80,119,57,78,219,45,89,218,98,164,145,212,106,86,60,57,28,206,188,138,156,223,5,79,34,91,141,157,68,252,83,27,0,5,232,82,1,98,67,48,44,17,145,96,252,206,12,109,40,149,25,50,115,9,120,28,227,30,183,4,6,48,218,227,211,81,69,255,100,65,119,219,200,126,10,182,203,141,12,164,54,0,124,213,244,212,114,144,40,98,72,63,248,210,201,243,226,211,35,146,244,110,171,38,89,204,37,138,7,134,164,138,204,19,23,81,151,25,242,129,15,100,120,43,31,238,188,132,49,20,154,27,73,224,164,64,237,1,205,37,20,113,137,124,24,35,30,200,64,136,102,100,19,143,144,48,195,24,193,64,198,49,8,20,161,232,244,73,129,6,252,147,8,65,232,90,12,146,37,133,76,113,19,6,253,98,3,187,156,9,41,35,220,203,53,161,169,130,151,161,9,56,72,201,11,209,66,200,230,59,173,240,120,55,208,130,110,132,134,78,62,161,240,43,184,253,149,217,114,165,206,227,241,51,18,144,216,43,38,140,145,158,99,156,225,209,236,49,3,27,238,65,101,217,32,113,41,221,125,34,20,117,227,167,189,241,4,164,74,244,244,83,116,133,78,232,4,11,157,185,105,150,96,132,137,196,27,33,113,63,34,85,39,177,56,41,36,108,253,49,215,107,188,88,72,249,179,198,160,88,40,92,18,81,37,180,194,192,9,159,198,174,61,255,255,173,205,165,242,166,156,210,205,42,74,34,238,234,13,4,82,28,37,89,152,182,210,30,164,146,40,57,147,134,101,184,171,5,179,15,72,49,81,188,2,89,130,69,33,186,68,96,37,49,15,99,48,143,84,243,75,70,232,64,210,189,27,10,227,110,144,200,71,63,227,81,170,62,11,99,31,249,216,216,130,71,163,130,75,196,13,135,166,172,10,12,174,20,21,167,85,54,86,203,220,11,151,169,2,151,112,194,236,156,49,160,160,1,162,57,166,46,103,201,130,20,116,44,86,230,130,151,45,97,22,6,118,249,210,158,80,88,165,46,222,165,43,28,63,102,95,108,117,193,59,73,68,119,185,137,88,188,15,26,239,99,216,195,12,205,232,183,49,84,163,178,99,180,38,51,75,65,150,117,161,152,29,125,141,243,233,202,82,53,116,186,114,81,231,40,142,133,66,115,229,49,185,201,151,60,163,48,55,164,155,186,225,240,85,36,224,81,114,161,35,57,18,185,117,130,144,235,88,135,39,245,253,26,15,192,16,228,236,253,230,32,18,170,141,183,44,5,17,140,44,226,84,34,83,255,200,195,146,213,213,174,164,10,13,12,49,206,89,166,136,198,245,186,164,96,212,243,157,75,18,210,190,223,73,164,64,127,205,135,48,144,108,183,246,192,53,18,168,204,135,51,244,49,12,126,63,131,91,147,18,6,188,243,177,227,129,40,100,150,247,152,71,61,240,33,215,75,36,3,25,175,103,52,184,142,231,232,142,28,47,84,79,249,166,189,182,24,150,183,72,83,41,127,137,102,195,157,70,38,105,174,252,235,169,245,10,2,217,92,218,63,61,167,132,108,193,202,213,72,151,151,171,93,45,132,85,35,191,210,104,238,242,18,118,113,251,131,57,140,198,228,110,147,141,29,86,35,153,217,187,58,20,5,55,255,182,1,24,241,132,193,115,107,77,21,91,129,25,175,201,139,71,26,22,199,129,162,35,170,160,64,65,167,136,19,12,62,225,51,170,216,2,227,136,154,170,217,143,231,184,151,123,225,168,141,33,137,145,8,23,228,153,34,94,185,17,48,160,170,189,19,193,169,104,9,187,251,28,203,227,40,14,148,162,134,40,152,137,56,8,215,97,143,139,80,8,4,49,48,75,255,152,22,140,64,134,105,177,129,226,217,166,152,32,163,193,88,156,146,225,145,206,217,31,204,113,137,112,113,144,172,42,17,131,137,132,178,17,8,23,187,132,96,80,141,255,202,135,144,56,134,99,16,9,76,208,7,121,176,136,124,72,6,36,3,16,97,80,1,48,128,4,100,144,7,124,248,150,69,235,144,72,192,135,121,104,183,36,211,135,193,178,132,21,216,152,142,48,128,86,97,158,210,137,8,51,147,160,238,147,62,188,176,38,191,192,32,112,194,18,219,82,11,9,162,26,115,18,33,175,48,0,3,50,179,179,81,154,197,169,179,151,185,129,159,17,180,231,195,172,49,33,168,199,18,51,61,108,150,219,216,179,60,187,147,24,176,11,199,2,39,179,104,22,229,48,48,239,240,185,42,162,66,125,200,4,163,179,132,78,232,177,123,96,3,24,96,6,154,0,188,178,232,174,197,16,64,165,64,131,86,51,47,95,105,142,98,177,129,139,74,149,6,42,198,141,209,58,233,170,26,63,225,19,230,193,145,227,97,181,52,138,9,142,137,47,64,130,47,230,1,193,250,210,28,255,255,136,65,235,48,22,140,136,157,89,251,168,93,123,168,35,145,137,69,208,2,22,113,35,27,8,134,69,64,15,163,176,148,24,76,150,173,104,63,48,251,50,168,83,22,195,1,49,154,112,59,154,104,136,12,27,182,149,64,9,184,243,170,2,81,136,204,40,37,28,155,7,130,115,180,248,139,136,46,148,7,100,16,60,38,179,1,121,8,134,215,75,134,121,192,7,201,144,135,125,208,7,78,120,195,75,123,136,253,200,11,248,17,137,99,144,186,60,201,10,141,35,33,18,130,190,222,112,21,48,83,57,162,193,11,204,178,38,59,187,38,204,50,39,60,97,154,209,170,26,54,169,173,40,130,10,9,28,202,6,124,147,164,140,57,64,195,166,2,147,13,0,192,8,75,40,10,0,56,168,255,82,153,124,160,67,72,152,148,244,48,3,123,48,134,198,248,47,72,248,147,135,8,139,86,147,173,181,112,53,139,98,175,169,184,57,86,161,32,109,236,31,125,57,59,128,228,40,62,155,28,183,40,142,107,36,139,177,208,130,223,57,156,180,3,30,229,88,40,192,73,204,18,17,153,102,255,123,65,97,33,25,149,193,143,102,11,151,44,67,30,45,248,49,242,16,137,48,184,143,118,91,48,41,131,4,49,240,163,129,184,20,18,251,193,156,160,45,118,228,145,48,194,170,30,161,30,70,50,49,213,204,176,251,210,16,142,32,17,117,113,134,203,24,16,73,216,7,79,153,135,125,192,4,72,16,6,213,64,20,132,88,176,135,176,142,72,152,167,124,216,135,210,33,201,181,98,178,139,0,131,239,32,160,187,0,0,220,140,150,201,1,0,208,82,196,107,194,184,210,162,166,79,251,19,187,240,201,58,83,173,183,72,173,176,48,160,115,82,185,148,51,68,68,84,57,87,89,156,30,240,165,149,187,139,95,76,191,167,33,63,98,106,139,171,217,11,30,193,73,108,186,141,130,185,7,102,112,6,97,0,157,233,9,10,78,96,12,180,147,7,163,11,6,51,32,203,120,168,163,209,40,46,3,64,56,54,0,9,63,113,203,46,122,34,179,160,174,39,122,40,129,17,166,200,249,32,45,50,14,228,136,129,174,115,26,190,177,192,42,201,70,33,20,65,202,12,41,192,121,144,137,255,24,21,205,139,157,233,208,81,251,18,71,225,209,28,75,184,15,217,169,65,51,80,209,87,97,199,187,137,132,96,8,6,121,184,143,75,177,165,126,146,8,79,153,142,225,155,149,27,232,151,203,73,152,223,184,156,197,75,152,23,250,145,74,162,36,21,49,177,139,233,170,133,120,145,151,64,24,146,88,4,101,196,132,192,82,195,81,121,8,27,216,169,123,208,2,75,32,46,119,242,136,72,16,206,204,136,132,215,235,74,123,136,1,59,5,131,89,114,7,97,88,43,48,24,6,84,98,43,92,41,173,61,227,13,238,11,38,108,122,11,173,193,18,146,0,202,95,90,173,213,66,62,154,36,161,183,112,173,20,26,147,213,242,10,107,250,190,114,82,203,238,227,154,56,41,11,173,25,11,238,243,11,66,19,33,199,170,8,227,88,47,170,172,136,132,147,211,125,41,40,102,88,80,92,165,178,9,133,132,218,185,61,7,27,75,152,26,13,42,12,138,227,212,75,160,185,32,193,64,142,44,130,58,0,106,28,42,202,34,241,154,64,67,50,36,42,121,142,166,160,46,103,173,154,228,255,80,81,101,60,158,145,72,47,108,164,8,185,51,8,9,217,29,139,176,4,0,137,176,102,195,15,221,49,150,165,176,9,191,121,36,185,147,137,112,244,209,244,82,14,69,192,132,32,107,138,185,186,82,24,72,15,182,209,29,171,50,136,104,185,21,117,156,158,240,185,82,34,44,22,144,145,137,247,120,31,131,36,60,204,97,77,228,104,145,137,237,35,48,72,134,99,208,55,136,8,10,45,128,49,119,5,6,5,51,159,123,72,136,221,171,47,235,16,134,73,217,7,122,224,4,99,0,0,48,216,66,110,89,206,193,218,5,100,40,73,76,96,201,195,106,10,52,16,147,231,187,166,27,160,190,77,36,138,170,32,29,142,59,207,59,33,207,95,138,90,191,40,63,251,52,139,232,112,213,193,176,51,157,108,184,50,243,26,230,249,160,137,19,161,6,98,161,167,233,21,166,96,76,21,37,143,237,48,3,120,52,71,69,9,9,214,184,52,96,128,140,120,176,132,120,72,148,73,177,135,96,96,134,117,128,132,177,12,134,116,91,163,67,146,174,87,225,40,22,218,25,101,164,85,192,255,192,8,138,178,58,190,17,38,110,53,70,167,193,218,101,4,81,150,236,64,143,216,2,14,92,150,250,192,15,144,9,16,192,131,187,119,69,8,144,216,57,224,24,142,200,67,139,105,133,86,142,0,134,44,154,175,12,225,28,8,9,3,15,17,76,225,68,6,24,56,149,164,219,189,191,185,59,243,26,163,165,192,87,81,139,162,50,93,8,50,2,183,37,204,48,129,202,170,48,80,218,112,241,151,173,154,144,51,216,200,143,80,15,70,200,93,225,132,89,125,96,143,219,145,4,192,5,3,83,194,7,142,0,157,184,181,132,159,208,130,100,85,1,125,48,141,121,24,172,237,189,74,0,249,140,218,146,138,79,220,146,189,48,185,242,4,32,189,152,78,112,26,213,153,41,173,24,80,129,17,210,11,175,128,213,193,48,57,47,73,213,136,91,51,199,186,79,192,208,138,198,64,26,163,153,218,184,128,173,137,59,68,156,160,141,189,194,140,42,12,16,68,193,83,16,153,87,215,216,194,185,85,132,149,125,12,210,67,37,121,16,6,126,50,15,97,104,48,72,8,134,179,220,173,134,255,202,192,66,106,150,139,186,168,173,216,165,230,224,27,172,107,71,28,137,162,101,76,14,172,209,130,149,100,149,88,251,26,111,97,67,132,0,16,160,64,16,251,66,216,102,67,88,45,221,29,51,208,150,95,233,24,29,109,11,35,246,149,218,176,178,121,196,17,129,84,215,190,251,156,37,121,12,75,32,160,2,81,151,218,137,141,201,145,40,0,66,226,34,89,140,197,203,143,116,221,204,135,192,30,94,105,12,223,18,18,37,20,40,103,1,49,49,118,150,137,96,37,117,244,171,203,32,137,192,74,78,8,245,222,48,184,135,135,96,155,121,152,7,42,227,22,187,105,137,204,208,211,201,232,60,192,105,10,72,48,67,233,76,134,213,128,132,0,152,218,46,35,11,55,169,19,6,162,73,96,170,172,107,42,213,210,130,101,107,82,138,43,73,62,166,76,45,142,203,95,10,20,64,112,74,154,196,73,160,46,210,26,1,140,45,252,253,69,103,13,12,218,74,139,123,105,10,145,184,147,142,208,157,72,48,128,228,196,46,24,56,203,160,8,149,131,2,131,187,125,141,207,64,148,75,255,59,15,187,237,167,100,197,22,158,32,156,238,226,225,108,253,18,228,113,40,99,236,40,35,38,164,107,45,142,86,27,11,111,101,149,223,216,183,81,81,4,83,97,52,224,8,10,29,45,36,33,52,22,113,188,215,53,50,150,23,10,149,164,250,203,144,152,180,72,104,13,104,51,22,39,86,151,125,41,232,8,123,19,48,48,128,135,224,184,106,196,182,196,91,156,44,155,21,233,98,92,123,141,22,144,57,146,170,194,30,201,83,66,173,194,136,249,108,17,17,219,159,233,16,136,14,44,16,141,80,1,24,176,178,250,194,140,82,90,31,119,197,7,69,136,129,242,41,136,21,192,4,69,56,195,123,232,183,179,188,4,73,200,50,3,144,129,231,176,89,73,208,7,119,106,214,175,192,38,80,21,33,166,176,223,220,88,51,56,83,11,150,251,95,107,18,96,21,88,173,164,88,57,1,126,11,211,218,212,63,129,37,19,154,68,224,16,63,242,66,179,51,91,220,236,179,84,6,154,185,134,106,21,12,118,156,190,184,168,103,12,12,121,188,151,136,160,213,61,196,143,160,0,42,24,255,150,7,6,75,186,42,60,143,227,50,10,144,194,15,100,244,162,103,12,204,36,54,215,62,17,140,42,114,10,121,60,158,170,1,161,198,226,27,107,116,28,182,192,149,250,128,102,221,9,199,207,225,138,238,2,142,193,118,159,251,186,13,251,178,47,45,244,22,139,64,59,129,73,20,246,216,63,124,0,142,226,1,17,33,181,129,197,75,40,198,178,129,45,120,164,178,200,142,44,171,45,36,157,53,113,141,1,77,242,65,231,137,144,143,241,151,111,75,177,199,188,16,162,88,9,38,84,66,247,57,200,205,77,150,139,168,102,54,94,171,24,17,172,105,201,148,121,16,138,188,66,20,124,64,217,221,211,135,124,0,162,27,73,102,136,112,26,105,121,196,94,254,142,193,94,129,153,179,44,219,18,19,215,170,10,58,83,224,88,134,196,239,8,0,88,198,147,239,179,79,183,112,84,80,205,207,182,96,57,80,107,18,143,254,178,196,107,184,155,52,47,164,32,166,10,236,31,86,253,180,232,130,168,102,113,172,231,45,18,208,185,155,106,190,7,158,98,113,158,130,129,72,136,27,118,255,153,113,184,211,81,88,43,146,104,109,14,90,45,76,35,50,158,101,89,22,114,213,40,101,25,12,92,225,214,226,0,3,212,53,232,104,109,233,141,93,215,111,252,164,243,137,8,118,125,136,216,240,47,68,129,7,22,15,134,186,117,176,111,17,144,101,11,48,52,96,180,200,240,17,224,104,16,27,88,1,137,186,31,198,139,142,106,188,139,216,82,32,124,125,158,115,179,77,48,64,131,72,128,146,43,37,228,142,32,138,130,177,87,136,152,79,44,221,182,140,229,192,73,90,137,239,250,48,51,192,135,215,219,7,124,248,30,90,57,158,151,232,75,241,45,21,117,49,0,97,232,47,119,237,146,149,84,139,100,208,135,251,160,207,158,40,207,23,173,44,152,147,198,172,41,90,81,141,90,159,100,11,241,139,101,60,49,197,149,3,0,155,182,79,144,43,79,177,141,90,6,194,10,178,155,25,45,147,202,85,100,235,112,90,75,242,194,196,75,212,207,107,189,10,22,100,201,227,16,166,192,49,162,190,171,194,216,8,10,160,136,151,39,149,242,133,128,8,20,167,209,164,12,156,237,255,146,154,121,110,162,199,209,203,84,123,86,52,241,235,30,254,26,155,152,87,117,215,29,1,249,175,140,89,52,198,100,12,2,241,145,92,137,83,242,16,144,117,80,143,73,123,180,100,227,22,138,232,23,132,232,136,132,240,48,243,185,149,96,140,179,171,101,235,11,130,165,71,125,164,178,145,237,132,84,65,205,177,48,29,81,222,127,41,72,142,50,99,154,128,88,170,138,164,237,249,157,72,128,171,5,83,116,47,20,109,30,193,177,190,184,145,132,234,158,196,60,164,173,115,102,149,196,113,22,66,10,23,181,89,2,151,62,168,137,56,168,217,146,164,152,101,213,194,172,99,82,117,71,53,69,251,77,188,163,189,45,60,225,121,178,109,139,54,195,117,201,205,79,54,147,57,113,114,115,253,180,68,152,211,15,114,61,47,86,113,28,104,253,225,43,130,138,59,185,232,89,127,99,57,99,21,236,0,37,142,74,14,110,127,235,34,199,186,41,42,215,35,65,81,4,116,53,172,129,57,128,70,204,180,215,185,136,48,10,39,182,161,100,53,138,5,235,83,42,95,215,100,96,180,246,98,88,239,130,182,129,224,140,228,220,173,141,185,125,61,142,40,136,48,186,1,38,131,129,148,25,137,1,59,120,19,101,115,202,89,120,167,116,202,33,28,162,48,80,138,126,30,141,97,25,248,64,22,193,153,16,55,172,218,15,139,151,36,214,175,176,76,153,148,192,154,140,73,129,124,140,136,144,175,53,3,169,23,22,23,11,98,228,145,231,108,133,113,234,138,4,21,8,8,0,59";

                var len = newByteArray.Split(',').Length;
                var arrBytes = new byte[len];

                var c = 0;
                foreach (var i in newByteArray.Split(','))
                {
                    arrBytes[c] = byte.Parse(i);
                    c++;
                }

                return Image.FromStream(new MemoryStream(arrBytes));

            }
        }


        public static bool Barrage
        {
            get
            {
                var Barrage = ConfigFile.ReadValue("HunterBeastmastery", "Barrage").Trim();

                return Barrage != "" && Convert.ToBoolean(Barrage);
            }
            set { ConfigFile.WriteValue("HunterBeastmastery", "Barrage", value.ToString()); }
        }

        private static bool Crow
        {
            get
            {
                var Crow = ConfigFile.ReadValue("HunterBeastmastery", "Crow").Trim();

                return Crow != "" && Convert.ToBoolean(Crow);
            }
            set { ConfigFile.WriteValue("HunterBeastmastery", "Crow", value.ToString()); }
        }
        private static bool Death
        {
            get
            {
                var Death = ConfigFile.ReadValue("HunterBeastmastery", "Death").Trim();

                return Death != "" && Convert.ToBoolean(Death);
            }
            set { ConfigFile.WriteValue("HunterBeastmastery", "Death", value.ToString()); }
        }
        private static bool Exhil
        {
            get
            {
                var Exhil = ConfigFile.ReadValue("HHunterBeastmastery", "Exhil").Trim();

                return Exhil != "" && Convert.ToBoolean(Exhil);
            }
            set { ConfigFile.WriteValue("HunterBeastmastery", "Exhil", value.ToString()); }
        }
        private static bool dpscooldowns
        {
            get
            {
                var dpscooldowns = ConfigFile.ReadValue("HunterBeastmastery", "dpscooldowns").Trim();

                return dpscooldowns != "" && Convert.ToBoolean(dpscooldowns);
            }
            set { ConfigFile.WriteValue("HunterBeastmastery", "dpscooldowns", value.ToString()); }
        }
        private static bool Turtle
        {
            get
            {
                var Turtle = ConfigFile.ReadValue("HunterBeastmastery", "Turtle").Trim();

                return Turtle != "" && Convert.ToBoolean(Turtle);
            }
            set { ConfigFile.WriteValue("HunterBeastmastery", "Turtle", value.ToString()); }
        }
        private static bool CounterShot
        {
            get
            {
                var CounterShot = ConfigFile.ReadValue("HunterBeastmastery", "CounterShot").Trim();

                return CounterShot != "" && Convert.ToBoolean(CounterShot);
            }
            set { ConfigFile.WriteValue("HunterBeastmastery", "CounterShot", value.ToString()); }
        }		
    }
}



/*
[AddonDetails.db]
AddonAuthor=Vectarius
AddonName=NPCScan
WoWVersion=Legion - 70100
[SpellBook.db]
Spell,83245,Wolf,F1
Spell,120679,Dire Beast,D1
Spell,217200,Dire Frenzy,D1
Spell,193455,Cobra Shot,D3
Spell,2643,Multi-Shot,D4
Spell,34026,Kill Command,D2
Spell,19574,Bestial Wrath,F
Spell,131894,A Murder of Crows,D5
Spell,120360,Barrage,None
Spell,147362,Counter Shot,R
Spell,193530,Aspect of the Wild,F8
Spell,20572,Blood Fury,F9
Spell,207068,Titan's Thunder,E
Spell,5116,Concussive,None
Spell,109304,Exhil,None
Spell,186265,Turtle,None
Spell,5384,Death,None
Spell,127834,Ancient Healing Potion,F5
Spell,133940,Silkweave Bandage,None
Spell,55709,Phoenix,F6
Spell,5512,Healthstone,F7
Spell,982,Revive Pet,V
Spell,142117,Potion Power,F10
Spell,136,Heal Pet,V
Aura,186265,Turtle
Aura,11196,Bandaged
Aura,234143,Temptation
Aura,2825,Bloodlust
Aura,80353,Time Warp
Aura,90355,Ancient Hysteria
Aura,160452,Netherwinds
Aura,146613,Drums
Aura,32182,Heroism
Aura,229206,Potion Power
Aura,19574,Bestial Wrath
Aura,118455,Beast Cleave
Aura,193530,Aspect of the Wild
*/
