using JMZ.Crafting.Data;
using JMZ.Crafting.Data.Models;
using JMZ.Dashboard.Mappers;

namespace JMZ.Dashboard.Boards.Craft;

public partial class CraftBoard : Form
{
    private ToolTip _toolTip = new();

    private List<Recipe> recipeList = [];

    private readonly CraftComponentHelper craftComponentHelper;

    private readonly CraftCategoryHelper craftCategoryHelper;

    public bool needsSetup = true;

    public List<Recipe> Recipes()
    {
        return this.recipeList;
    }

    public List<Category> Categories()
    {
        return this.craftCategoryHelper.Categories();
    }

    public void TrackedToSavedRecipes()
    {
        // clear the existing list.
        this.recipeList.Clear();

        // iterate over the tracked list.
        foreach (var recipe in this.listboxRecipes.Items)
        {
            // add each item from the tracked list into the list to be saved.
            this.recipeList.Add((Recipe)recipe);
        }
    }
    
    public void TrackedToSavedCategories()
    {
        // command the owning category list owner to update their categories for saving.
        this.craftCategoryHelper.TrackedToSavedCategories();
    }

    public CraftBoard()
    {
        InitializeComponent();

        craftComponentHelper = new();
        craftCategoryHelper = new();
        this.SetupBoards();

        this.InitializeDataControls();
        this.InitializeTooltips();
        this.ApplyUpdateEvents();
    }

    private void SetupBoards()
    {
        this.craftComponentHelper.FormClosing += HideBoard;
        this.craftComponentHelper.Setup();

        this.craftCategoryHelper.FormClosing += HideBoard;
    }

    /// <summary>
    /// An event handler for hiding the boards instead of closing them.
    /// </summary>
    private static void HideBoard(object? sender, FormClosingEventArgs e)
    {
        // make sure its the user trying to close the window, first.
        if (e.CloseReason != CloseReason.UserClosing) return;

        // actually don't close and dispose of the window.
        e.Cancel = true;

        // hide the window instead.
        ((Form)sender!).Hide();
    }

    #region init
    /// <summary>
    /// Initializes the data-binding of components to arbitrary values.
    /// </summary>
    private void InitializeDataControls()
    {
        // setup the main list box of SDPs.
        this.listboxRecipes.DisplayMember = "Key";
        this.listboxRecipes.ValueMember = "Name";

        this.listBoxIngredients.DisplayMember = "Name";
        this.listBoxIngredients.ValueMember = "Id";

        this.listBoxTools.DisplayMember = "Name";
        this.listBoxTools.ValueMember = "Id";

        this.listBoxOutput.DisplayMember = "Name";
        this.listBoxOutput.ValueMember = "Id";

        this.listBoxCategories.DisplayMember = "Name";
        this.listBoxCategories.ValueMember = "Key";
    }

    /// <summary>
    /// Initializes all tooltips associated with this board.
    /// </summary>
    private void InitializeTooltips()
    {
        _toolTip = new();
        _toolTip.AutoPopDelay = 5000;
        _toolTip.InitialDelay = 1000;
        _toolTip.ReshowDelay = 500;
        _toolTip.ToolTipIcon = ToolTipIcon.Info;
        _toolTip.ToolTipTitle = "Details and Usage";

        var keyTip = """
            The unique identifying key of the recipe.
            Use this to refer to this recipe when using various plugin commands or scripts.
            
            This is required, and will cause issues if left blank.
            """;
        _toolTip.SetToolTip(this.textBox_key, keyTip);

        var nameTip = """
            The name of the recipe.
            
            This is not required.
            Leave blank to use the first output's name.
            """;
        _toolTip.SetToolTip(this.textBox_name, nameTip);

        var descriptionTip = """
            The description of the recipe.
            
            This is not required.
            Leave blank to use the first output's name.
            """;
        _toolTip.SetToolTip(this.textBoxDescription, descriptionTip);

        var iconIndexTip = """
            The icon index for this recipe.
            
            This is not required.
            Set to -1 to use the first output's icon.
            """;
        _toolTip.SetToolTip(this.num_iconIndex, iconIndexTip);

        var unlockedByDefaultTip = """
            Whether or not this recipe is unlocked by default.
            
            If checked, then this recipe will be available as soon as one of the recipe categories are unlocked.
            If unchecked, then the recipe must be unlocked before it shows up in the list.
            """;
        _toolTip.SetToolTip(this.checkBox_unlockedByDefault, unlockedByDefaultTip);

        var maskedUntilCraftedTip = """
            Whether or not this recipe is masked by default.
            
            If checked, then this recipe will have various values obfuscated with ?s until it is crafted.
            If unchecked, then the recipe will have all details visible regardless of being crafted or not.
            """;
        _toolTip.SetToolTip(this.checkBox_maskedUntilCrafted, maskedUntilCraftedTip);

        var ingredientsTip = """
            The list of ingredients required to craft this recipe.
            
            Ingredients are crafting components that are consumed when the recipe is crafted.
            """;
        _toolTip.SetToolTip(this.labelHelpIngredients, ingredientsTip);

        var toolsTip = """
            The list of tools required to craft this recipe.
            
            Tools are crafting components that are NOT consumed when the recipe is crafted.
            """;
        _toolTip.SetToolTip(this.labelHelpTools, toolsTip);

        var outputsTip = """
            The list of outputs created when this recipe is crafted.
            
            Outputs are crafting components that are given to the player when the recipe is crafted.
            """;
        _toolTip.SetToolTip(this.labelHelpOutput, outputsTip);

        var ingredientsCloningTip = """
            Click to clone the currently-selected crafting component
            in the Crafting Component Helper window into the list of ingredients.
            
            It is recommended to keep the helper window open if creating new recipes.
            """;
        _toolTip.SetToolTip(this.buttonCloneToIngredients, ingredientsCloningTip);

        var ingredientDeletingTip = "Click to remove the selected ingredient from the list.";
        _toolTip.SetToolTip(this.buttonDeleteIngredient, ingredientDeletingTip);

        var toolsCloningTip = """
            Click to clone the currently-selected crafting component
            in the Crafting Component Helper window into the list of tools.
            
            It is recommended to keep the helper window open if creating new recipes.
            """;
        _toolTip.SetToolTip(this.buttonCloneToTools, toolsCloningTip);

        var toolDeletingTip = "Click to remove the selected tool from the list.";
        _toolTip.SetToolTip(this.buttonDeleteTool, toolDeletingTip);

        var outputsCloningTip = """
            Click to clone the currently-selected crafting component
            in the Crafting Component Helper window into the list of outputs.
            
            It is recommended to keep the helper window open if creating new recipes.
            """;
        _toolTip.SetToolTip(this.buttonCloneToOutputs, outputsCloningTip);

        var outputDeletingTip = "Click to remove the selected output from the list.";
        _toolTip.SetToolTip(this.buttonDeleteOutput, outputDeletingTip);

        var componentHelperTip = """
            Click to reveal the Crafting Component Helper window.
            This window is used to quickly derive ingredients/tools/outputs for a recipe.
            
            It is recommended to keep the helper window open if creating new recipes.
            """;
        _toolTip.SetToolTip(this.buttonComponentHelper, componentHelperTip);

        var categoryHelperTip = """
            Click to reveal the Crafting Category Helper window.
            This window is used to create/edit/delete crafting categories.
            
            It is also used by cloning the currently-selected category into the recipe.
            
            It is recommended to keep the helper window open if creating new recipes.
            """;
        _toolTip.SetToolTip(this.buttonComponentHelper, categoryHelperTip);

        var newRecipeTip = """
            Click to add a new recipe to the list.
            This will generate a mostly-blank recipe.
            """;
        _toolTip.SetToolTip(this.buttonAddRecipe, newRecipeTip);

        var cloneRecipeTip = "Click to clone the currently-selected recipe into the list at the next index.";
        _toolTip.SetToolTip(this.buttonCloneRecipe, cloneRecipeTip);

        var deleteRecipeTip = "Click to delete the currently-selected recipe.";
        _toolTip.SetToolTip(this.buttonDeleteRecipe, deleteRecipeTip);
    }

    private void ApplyUpdateEvents()
    {
        this.ApplyUpdateEventsForCoreData();

        this.listboxRecipes.SelectedIndexChanged += this.RefreshForm;
    }

    private void ApplyUpdateEventsForCoreData()
    {
        this.textBox_key.TextChanged += this.UpdateKey;
        this.textBox_name.TextChanged += this.UpdateName;
        this.textBoxDescription.TextChanged += this.UpdateDescription;
        this.num_iconIndex.ValueChanged += this.UpdateIconIndex;
        this.checkBox_unlockedByDefault.CheckedChanged += this.UpdateUnlockedByDefault;
    }
    #endregion

    #region update
    private void UpdateKey(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (Recipe)this.listboxRecipes.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // update with the new value.
        item.Key = this.textBox_key.Text;
    }

    private void UpdateName(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (Recipe)this.listboxRecipes.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // update the name with the new value.
        item.Name = this.textBox_name.Text;

        // the name is special in that it needs to be synced with the list to ensure name updates apply.
        this.listboxRecipes.Items[this.listboxRecipes.SelectedIndex] = item;
    }

    private void UpdateDescription(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (Recipe)this.listboxRecipes.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // update the name with the new value.
        item.Description = this.textBoxDescription.Text;
    }

    private void UpdateIconIndex(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (Recipe)this.listboxRecipes.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // update with the new value.
        item.IconIndex = (int)this.num_iconIndex.Value;
    }

    private void UpdateUnlockedByDefault(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (Recipe)this.listboxRecipes.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // update with the new value.
        item.UnlockedByDefault = this.checkBox_unlockedByDefault.Checked;
    }
    #endregion

    #region refresh
    private void RefreshForm(object? sender, EventArgs e)
    {
        this._RefreshForm();
    }

    private void _RefreshForm()
    {
        // refresh recipe data.
        this.RefreshRecipes();

        this.RenderCategories();
        this.RenderIngredients();
        this.RenderTools();
        this.RenderOutputs();
    }

    private void RefreshRecipes()
    {
        var selectedItem = (Recipe)this.listboxRecipes.SelectedItem!;
        if (selectedItem == null) return;

        // core data
        this.textBox_key.Text = selectedItem.Key;
        this.textBox_name.Text = selectedItem.Name;
        this.textBoxDescription.Text = selectedItem.Description;
        this.num_iconIndex.Value = selectedItem.IconIndex;
        this.checkBox_unlockedByDefault.Checked = selectedItem.UnlockedByDefault;
        this.checkBox_maskedUntilCrafted.Checked = selectedItem.MaskedUntilCrafted;
    }

    private void RenderCategories()
    {
        this.listBoxCategories.Items.Clear();

        var selectedItem = (Recipe)this.listboxRecipes.SelectedItem!;

        // check to make sure we have an item to work with.
        if (selectedItem == null)
        {
            // stop processing.
            return;
        }

        if (selectedItem.CategoryKeys.Count == 0) return;

        selectedItem.CategoryKeys.ForEach(category =>
        {
            this.listBoxCategories.Items.Add(category);
        });
    }

    private void RenderIngredients()
    {
        this.listBoxIngredients.Items.Clear();

        var selectedItem = (Recipe)this.listboxRecipes.SelectedItem!;

        // check to make sure we have an item to work with.
        if (selectedItem is null) return;
        if (selectedItem.Ingredients.Count == 0) return;

        selectedItem.Ingredients.ForEach(ingredient =>
        {
            if (ingredient.MissingDisplayName)
            {
                ingredient.Name = ingredient.GetDisplayName();
            }

            this.listBoxIngredients.Items.Add(ingredient);
        });
    }

    private void RenderTools()
    {
        this.listBoxTools.Items.Clear();

        var selectedItem = (Recipe)this.listboxRecipes.SelectedItem!;

        // check to make sure we have an item to work with.
        if (selectedItem == null)
        {
            // stop processing.
            return;
        }

        if (selectedItem.Tools.Count == 0) return;

        selectedItem.Tools.ForEach(ingredient =>
        {
            if (ingredient.MissingDisplayName)
            {
                ingredient.Name = ingredient.GetDisplayName();
            }

            this.listBoxTools.Items.Add(ingredient);
        });
    }

    private void RenderOutputs()
    {
        this.listBoxOutput.Items.Clear();

        var selectedItem = (Recipe)this.listboxRecipes.SelectedItem!;

        // check to make sure we have an item to work with.
        if (selectedItem == null)
        {
            // stop processing.
            return;
        }

        if (selectedItem.Outputs.Count == 0) return;

        selectedItem.Outputs.ForEach(ingredient =>
        {
            if (ingredient.MissingDisplayName)
            {
                ingredient.Name = ingredient.GetDisplayName();
            }

            this.listBoxOutput.Items.Add(ingredient);
        });
    }
    #endregion

    #region setup
    public void Setup(CraftingConfiguration craftingConfiguration)
    {
        // check to make sure we need to run the setup before running it.
        if (!this.needsSetup) return;

        // populate the list.
        this.PopulateRecipeList(craftingConfiguration.Recipes);

        // populate the list.
        this.PopulateCategoryList(craftingConfiguration.Categories);

        // check if we need to autopick an index.
        if (this.listboxRecipes.SelectedIndex == -1 && this.listboxRecipes.Items.Count > 0)
        {
            // set the index to the first item.
            this.listboxRecipes.SelectedIndex = 0;
        }

        // let this form know we've finished setup.
        this.SetupComplete();
    }

    private void PopulateRecipeList(List<Recipe> recipes)
    {
        // empty the list first.
        this.listboxRecipes.Items.Clear();

        // assign the list of items locally to the form.
        this.recipeList = recipes;

        // iterate over each of the entries in the list.
        this.recipeList.ForEach(recipe =>
        {
            // if any entry is null somehow, skip it.
            if (recipe is null) return;

            // add the entry to the running list.
            this.listboxRecipes.Items.Add(recipe);
        });
    }

    private void PopulateCategoryList(List<Category> categories)
    {
        // empty the list first.
        this.listBoxCategories.Items.Clear();

        // also setup the category helper.
        this.craftCategoryHelper.Setup(categories);
    }

    private void SetupComplete()
    {
        this.needsSetup = false;
    }
    #endregion

    #region component helper
    private void buttonComponentHelper_Click(object sender, EventArgs e)
    {
        this.craftComponentHelper.Show();
    }


    private void buttonCloneToIngredients_Click(object sender, EventArgs e)
    {
        // determine the selected item.
        var item = (Recipe)this.listboxRecipes.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;
        
        // grab the current state of the component from the helper.
        var helperComponent = this.craftComponentHelper.CurrentComponent();

        // insert that item into the ingredients list.
        this.listBoxIngredients.Items.Add(helperComponent);
        
        // add the ingredient to the recipe, too.
        item.Ingredients.Add(helperComponent);
    }

    private void buttonDeleteIngredient_Click(object sender, EventArgs e)
    {
        // grab the currently selected item.
        var currentRecipe = (Recipe)this.listboxRecipes.SelectedItem!;

        // if there is no item selected, don't delete anything.
        if (currentRecipe is null) return;

        // shorthand the listbox for variablizing.
        var listbox = this.listBoxIngredients;

        // grab the selection the user is considering removing.
        var removalIndex = listbox.SelectedIndex;

        // check if there is no index selected right now.
        if (removalIndex == -1)
        {
            // do nothing.
            return;
        }

        var selectedItem = (Component)listbox.SelectedItem!;

        // remove the stuff.
        currentRecipe.Ingredients.Remove(selectedItem);
        listbox.Items.RemoveAt(removalIndex);
        if (listbox.Items.Count != 0)
        {
            listbox.SelectedIndex = 0;
        }
    }


    private void buttonCloneToTools_Click(object sender, EventArgs e)
    {
        // determine the selected item.
        var item = (Recipe)this.listboxRecipes.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;
        
        // grab the current state of the component from the helper.
        var helperComponent = this.craftComponentHelper.CurrentComponent();

        // insert that item into the ingredients list.
        this.listBoxTools.Items.Add(helperComponent);
        
        // add the ingredient to the recipe, too.
        item.Tools.Add(helperComponent);
    }

    private void buttonDeleteTool_Click(object sender, EventArgs e)
    {
        // grab the currently selected item.
        var currentRecipe = (Recipe)this.listboxRecipes.SelectedItem!;

        // if there is no item selected, don't delete anything.
        if (currentRecipe is null) return;

        // shorthand the listbox for variablizing.
        var listbox = this.listBoxTools;

        // grab the selection the user is considering removing.
        var removalIndex = listbox.SelectedIndex;

        // check if there is no index selected right now.
        if (removalIndex == -1)
        {
            // do nothing.
            return;
        }

        var selectedItem = (Component)listbox.SelectedItem!;

        // remove the tool.
        currentRecipe.Tools.Remove(selectedItem);
        listbox.Items.RemoveAt(removalIndex);
        if (listbox.Items.Count != 0)
        {
            listbox.SelectedIndex = 0;
        }
    }


    private void buttonCloneToOutputs_Click(object sender, EventArgs e)
    {
        // determine the selected item.
        var item = (Recipe)this.listboxRecipes.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;
        
        // grab the current state of the component from the helper.
        var helperComponent = this.craftComponentHelper.CurrentComponent();

        // insert that item into the ingredients list.
        this.listBoxOutput.Items.Add(helperComponent);
        
        // add the ingredient to the recipe, too.
        item.Outputs.Add(helperComponent);
    }

    private void buttonDeleteOutput_Click(object sender, EventArgs e)
    {
        // grab the currently selected item.
        var currentRecipe = (Recipe)this.listboxRecipes.SelectedItem!;

        // if there is no item selected, don't delete anything.
        if (currentRecipe is null) return;

        // shorthand the listbox for variablizing.
        var listbox = this.listBoxOutput;

        // grab the selection the user is considering removing.
        var removalIndex = listbox.SelectedIndex;

        // check if there is no index selected right now.
        if (removalIndex == -1)
        {
            // do nothing.
            return;
        }

        var selectedItem = (Component)listbox.SelectedItem!;

        // remove the output.
        currentRecipe.Outputs.Remove(selectedItem);
        listbox.Items.RemoveAt(removalIndex);
        if (listbox.Items.Count != 0)
        {
            listbox.SelectedIndex = 0;
        }
    }
    #endregion

    #region category helper
    private void buttonCategoryHelper_Click(object sender, EventArgs e)
    {
        this.craftCategoryHelper.Show();
    }

    private void buttonAddCategory_Click(object sender, EventArgs e)
    {
        // grab the current state of the component from the helper.
        var helperCategory = this.craftCategoryHelper.CurrentCategory();

        // do nothing if the category is null/unselected.
        if (helperCategory is null) return;

        // grab the currently selected item.
        var currentRecipe = (Recipe)this.listboxRecipes.SelectedItem!;

        // if there is no item selected, don't delete anything.
        if (currentRecipe is null) return;

        // check if the category already exists in the recipe.
        var alreadyHasCategory = this.listBoxCategories.Items.Contains(helperCategory.Key) ||
            currentRecipe.CategoryKeys.Contains(helperCategory.Key);

        // pivot on whether or not the category already exists.
        if (alreadyHasCategory)
        {
            // do nothing.
            return;
        }

        // insert that item into the ingredients list.
        this.listBoxCategories.Items.Add(helperCategory.Key);

        // add the category to the recipe, too.
        currentRecipe.CategoryKeys.Add(helperCategory.Key);
    }

    private void buttonDeleteCategory_Click(object sender, EventArgs e)
    {
        // grab the currently selected item.
        var currentRecipe = (Recipe)this.listboxRecipes.SelectedItem!;

        // if there is no item selected, don't delete anything.
        if (currentRecipe is null) return;

        // shorthand the listbox for variablizing.
        var listbox = this.listBoxCategories;

        // grab the selection the user is considering removing.
        var removalIndex = listbox.SelectedIndex;

        // check if there is no index selected right now.
        if (removalIndex == -1)
        {
            // do nothing.
            return;
        }

        var selectedItem = (string)listbox.SelectedItem!;

        // define the prompt.
        var removalPrompt = $"Are you sure you want to remove the selected category key, [{selectedItem}]?";

        // show the box with the prompt.
        var dialogResult = MessageBox.Show(
            removalPrompt,
            "Removing a category",
            MessageBoxButtons.OKCancel);

        // pivot on the user decisions.
        switch (dialogResult)
        {
            case DialogResult.OK:
                currentRecipe.CategoryKeys.Remove(selectedItem);
                listbox.Items.RemoveAt(removalIndex);
                if (listbox.Items.Count != 0)
                {
                    listbox.SelectedIndex = 0;
                }

                break;
            case DialogResult.Cancel:
                break;
        }
    }
    #endregion

    private void buttonAddRecipe_Click(object sender, EventArgs e)
    {
        // define the new recipe.
        var newItem = new Recipe
        {
            Name = "===NEW RECIPE===",
            Key = "new_recipe",
            Description = "a new recipe, ripe for a plump and savory definition."
        };

        // grab the current selection.
        var selectedIndex = this.listboxRecipes.SelectedIndex;

        // check if there was no current selection.
        if (selectedIndex == -1 || (selectedIndex == this.listboxRecipes.Items.Count - 1))
        {
            // add the item to the list without regard for index.
            this.listboxRecipes.Items.Add(newItem);
        }
        // we are in the middle somewhere.
        else
        {
            // add it at the given index.
            this.listboxRecipes.Items.Insert(selectedIndex, newItem);
        }
    }

    private void buttonDeleteRecipe_Click(object sender, EventArgs e)
    {
        // grab the selection the user is considering removing.
        var removalIndex = this.listboxRecipes.SelectedIndex;

        // check if there is no index selected right now.
        if (removalIndex == -1)
        {
            // do nothing.
            return;
        }

        // grab the current panel we're working with.
        var selectedItem = (Recipe)this.listboxRecipes.SelectedItem!;

        // define the prompt.
        var removalPrompt = $"Are you sure you want to remove the recipe with key [{selectedItem.Key}]?";

        // show the box with the prompt.
        var dialogResult = MessageBox.Show(
            removalPrompt,
            "Removing a Recipe",
            MessageBoxButtons.OKCancel);

        // pivot on the user decisions.
        switch (dialogResult)
        {
            case DialogResult.OK:
                this.listboxRecipes.Items.RemoveAt(removalIndex);
                if (this.listboxRecipes.Items.Count != 0)
                {
                    this.listboxRecipes.SelectedIndex = 0;
                }

                break;
            case DialogResult.Cancel:
                break;
        }
    }

    private void buttonCloneRecipe_Click(object sender, EventArgs e)
    {
        // grab the currently selected recipe.
        var selectedItem = (Recipe)this.listboxRecipes.SelectedItem!;

        // no cloning if there is no selected item.
        if (selectedItem is null) return;

        // define the new recipe.
        var clonedItem = new Recipe
        {
            Name = selectedItem.Name,
            Key = selectedItem.Key,
            Description = selectedItem.Description,
            IconIndex = selectedItem.IconIndex,
            MaskedUntilCrafted = selectedItem.MaskedUntilCrafted,
            UnlockedByDefault = selectedItem.UnlockedByDefault,
            
            // cloning by reference takes more work.
            Ingredients = [..selectedItem.Ingredients],
            Tools = [..selectedItem.Tools],
            Outputs = [..selectedItem.Outputs],
            CategoryKeys = [..selectedItem.CategoryKeys]
        };

        // grab the current selection.
        var selectedIndex = this.listboxRecipes.SelectedIndex;

        // check if there was no current selection.
        if (selectedIndex == -1 || (selectedIndex == this.listboxRecipes.Items.Count - 1))
        {
            // add the item to the list without regard for index.
            this.listboxRecipes.Items.Add(clonedItem);
        }
        // we are in the middle somewhere.
        else
        {
            // add it at the given index.
            this.listboxRecipes.Items.Insert(selectedIndex, clonedItem);
        }
    }
}