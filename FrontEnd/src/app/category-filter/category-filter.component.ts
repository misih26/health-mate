import { Component, OnInit } from '@angular/core';
import { RecipeService } from '../services/recipe.service';
import { ActivatedRoute } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-category-filter',
  imports: [CommonModule],
  templateUrl: './category-filter.component.html',
  styleUrl: './category-filter.component.css'
})
export class CategoryFilterComponent implements OnInit {
  categoryName: string = "";
  recipes: any[] = [];
  constructor(private recipeService: RecipeService, private route: ActivatedRoute) { }
  ngOnInit(): void {
    this.route.paramMap.subscribe(params => this.categoryName = params.get("name") + "")
    this.recipeService.getRecipesByCategory(this.categoryName)
      .subscribe(resp => this.recipes = resp.recipes)
  }

}

