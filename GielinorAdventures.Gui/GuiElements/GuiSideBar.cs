using GielinorAdventures.GameLogic.GameManagers;
using GielinorAdventures.Primitives;
using GielinorAdventures.Settings;

namespace GielinorAdventures.Gui.GuiElements
{
    public class GuiSideBar : GuiElement
    {
        IGameManager game;

        GuiSideBarPanel panel;
        GuiCombatPanel combatPanel;
        GuiSkillsPanel skillsPanel;
        GuiInventoryPanel inventoryPanel;

        GuiToggleButton combatButton;
        GuiToggleButton skillsButton;
        GuiToggleButton questsButton;
        GuiToggleButton tasksButton;
        GuiToggleButton inventoryButton;
        GuiToggleButton equipmentButton;
        GuiToggleButton prayerButton;
        GuiToggleButton spellsButton;
        GuiToggleButton exitButton;

        public override void LoadContent()
        {
            panel = new GuiSideBarPanel { Size = new Size2D(240, 262) };
            combatPanel = new GuiCombatPanel { Size = new Size2D(190, 262) };
            skillsPanel = new GuiSkillsPanel { Size = new Size2D(190, 262) };
            inventoryPanel = new GuiInventoryPanel { Size = new Size2D(190, 262) };

            combatButton = new GuiToggleButton
            {
                Texture = "Interface/SideBar/button",
                ButtonTileSize = new Size2D(30, 36),
                Icon = "Interface/SideBar/combat_button_icon",
                Size = new Size2D(30, 36)
            };
            skillsButton = new GuiToggleButton
            {
                Texture = "Interface/SideBar/button",
                ButtonTileSize = new Size2D(30, 36),
                Icon = "Interface/SideBar/skills_button_icon",
                Size = new Size2D(30, 36)
            };
            questsButton = new GuiToggleButton
            {
                Texture = "Interface/SideBar/button",
                ButtonTileSize = new Size2D(30, 36),
                Icon = "Interface/SideBar/quests_button_icon",
                Size = new Size2D(30, 36)
            };
            tasksButton = new GuiToggleButton
            {
                Texture = "Interface/SideBar/button",
                ButtonTileSize = new Size2D(30, 36),
                Icon = "Interface/SideBar/tasks_button_icon",
                Size = new Size2D(30, 36)
            };
            inventoryButton = new GuiToggleButton
            {
                Texture = "Interface/SideBar/button",
                ButtonTileSize = new Size2D(30, 36),
                Icon = "Interface/SideBar/inventory_button_icon",
                Size = new Size2D(30, 36)
            };
            equipmentButton = new GuiToggleButton
            {
                Texture = "Interface/SideBar/button",
                ButtonTileSize = new Size2D(30, 36),
                Icon = "Interface/SideBar/equipment_button_icon",
                Size = new Size2D(30, 36)
            };
            prayerButton = new GuiToggleButton
            {
                Texture = "Interface/SideBar/button",
                ButtonTileSize = new Size2D(30, 36),
                Icon = "Interface/SideBar/prayer_button_icon",
                Size = new Size2D(30, 36)
            };
            spellsButton = new GuiToggleButton
            {
                Texture = "Interface/SideBar/button",
                ButtonTileSize = new Size2D(30, 36),
                Icon = "Interface/SideBar/spells_button_icon",
                Size = new Size2D(30, 36)
            };
            exitButton = new GuiToggleButton
            {
                Texture = "Interface/SideBar/button",
                ButtonTileSize = new Size2D(30, 36),
                Icon = "Interface/SideBar/exit_button_icon",
                Size = new Size2D(240, 36)
            };

            Children.Add(panel);
            Children.Add(combatPanel);
            Children.Add(skillsPanel);
            Children.Add(inventoryPanel);

            Children.Add(combatButton);
            Children.Add(skillsButton);
            Children.Add(questsButton);
            Children.Add(tasksButton);
            Children.Add(inventoryButton);
            Children.Add(equipmentButton);
            Children.Add(prayerButton);
            Children.Add(spellsButton);
            Children.Add(exitButton);

            InventoryButton_Clicked(this, null);

            base.LoadContent();
        }

        public void AssociateGameManager(IGameManager game)
        {
            this.game = game;

            combatPanel.AssociateGameManager(game);
            skillsPanel.AssociateGameManager(game);
        }

        protected override void SetChildrenProperties()
        {
            base.SetChildrenProperties();

            exitButton.Location = new Point2D(
                Location.X + (Size.Width - exitButton.Size.Width) / 2,
                ClientRectangle.Bottom - GameDefines.GUI_TILE_SIZE);

            panel.Location = new Point2D(
                Location.X + (Size.Width - panel.Size.Width) / 2,
                exitButton.Location.Y - panel.Size.Height);
            combatPanel.Location = new Point2D(
                panel.Location.X + 25,
                panel.Location.Y);
            skillsPanel.Location = combatPanel.Location;
            inventoryPanel.Location = skillsPanel.Location;

            combatButton.Location = new Point2D(
                panel.Location.X,
                panel.Location.Y - combatButton.Size.Height);
            skillsButton.Location = new Point2D(
                combatButton.ClientRectangle.Right,
                combatButton.Location.Y);
            questsButton.Location = new Point2D(
                skillsButton.ClientRectangle.Right,
                skillsButton.Location.Y);
            tasksButton.Location = new Point2D(
                questsButton.ClientRectangle.Right,
                questsButton.Location.Y);
            inventoryButton.Location = new Point2D(
                tasksButton.ClientRectangle.Right,
                tasksButton.Location.Y);
            equipmentButton.Location = new Point2D(
                inventoryButton.ClientRectangle.Right,
                inventoryButton.Location.Y);
            prayerButton.Location = new Point2D(
                equipmentButton.ClientRectangle.Right,
                equipmentButton.Location.Y);
            spellsButton.Location = new Point2D(
                prayerButton.ClientRectangle.Right,
                prayerButton.Location.Y);
        }

        protected override void RegisterEvents()
        {
            combatButton.Clicked += CombatButton_Clicked;
            skillsButton.Clicked += SkillsButton_Clicked;
            questsButton.Clicked += QuestsButton_Clicked;
            tasksButton.Clicked += TasksButton_Clicked;
            inventoryButton.Clicked += InventoryButton_Clicked;
            equipmentButton.Clicked += EquipmentButton_Clicked;
            prayerButton.Clicked += PrayerButton_Clicked;
            spellsButton.Clicked += SpellsButton_Clicked;
            exitButton.Clicked += ExitButton_Clicked;
        }

        protected override void UnregisterEvents()
        {
            combatButton.Clicked -= CombatButton_Clicked;
            skillsButton.Clicked -= SkillsButton_Clicked;
            questsButton.Clicked -= QuestsButton_Clicked;
            tasksButton.Clicked -= TasksButton_Clicked;
            inventoryButton.Clicked -= InventoryButton_Clicked;
            equipmentButton.Clicked -= EquipmentButton_Clicked;
            prayerButton.Clicked -= PrayerButton_Clicked;
            spellsButton.Clicked -= SpellsButton_Clicked;
            exitButton.Clicked -= ExitButton_Clicked;
        }

        void CombatButton_Clicked(object sender, Input.Events.MouseButtonEventArgs e)
        {
            UnselectEverything();

            combatButton.Toggled = true;
            combatPanel.Show();
        }

        void SkillsButton_Clicked(object sender, Input.Events.MouseButtonEventArgs e)
        {
            UnselectEverything();

            skillsButton.Toggled = true;
            skillsPanel.Show();
        }

        void QuestsButton_Clicked(object sender, Input.Events.MouseButtonEventArgs e)
        {
            UnselectEverything();

            questsButton.Toggled = true;
        }

        void TasksButton_Clicked(object sender, Input.Events.MouseButtonEventArgs e)
        {
            UnselectEverything();

            tasksButton.Toggled = true;
        }

        void InventoryButton_Clicked(object sender, Input.Events.MouseButtonEventArgs e)
        {
            UnselectEverything();

            inventoryButton.Toggled = true;
            inventoryPanel.Show();
        }

        void EquipmentButton_Clicked(object sender, Input.Events.MouseButtonEventArgs e)
        {
            UnselectEverything();

            equipmentButton.Toggled = true;
        }

        void PrayerButton_Clicked(object sender, Input.Events.MouseButtonEventArgs e)
        {
            UnselectEverything();

            prayerButton.Toggled = true;
        }

        void SpellsButton_Clicked(object sender, Input.Events.MouseButtonEventArgs e)
        {
            UnselectEverything();

            spellsButton.Toggled = true;
        }

        void ExitButton_Clicked(object sender, Input.Events.MouseButtonEventArgs e)
        {
            UnselectEverything();

            exitButton.Toggled = true;
        }

        void UnselectEverything()
        {
            combatButton.Toggled = false;
            skillsButton.Toggled = false;
            questsButton.Toggled = false;
            tasksButton.Toggled = false;
            inventoryButton.Toggled = false;
            equipmentButton.Toggled = false;
            prayerButton.Toggled = false;
            spellsButton.Toggled = false;
            exitButton.Toggled = false;

            combatPanel.Hide();
            skillsPanel.Hide();
            inventoryPanel.Hide();
        }
    }
}
