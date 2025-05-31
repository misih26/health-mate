import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormsModule } from '@angular/forms';
import { RecipeService } from '../services/recipe.service';
import { CategoryService } from '../services/category.service';

@Component({
  selector: 'app-new-recipe',
  imports: [CommonModule, FormsModule],
  templateUrl: './new-recipe.component.html',
  styleUrl: './new-recipe.component.css'
})
export class NewRecipeComponent implements OnInit {
  title: string = "";
  description: string = "";
  category: string = "";
  categories: any[] = [];
  constructor(private recipeService: RecipeService, private categoryService: CategoryService) {
  }

  ngOnInit(): void {
    this.categoryService.getAllCategory()
      .subscribe(resp => this.categories = resp)
  }
  saveNewRecipes(): void {
    let newRecipes = {
      name: this.title,
      description: this.description,
      categoryId: this.category
    }
    this.recipeService.saveNewRecipe(newRecipes)
      .subscribe(resp => alert("SIkerres mentés"))
  }
}
