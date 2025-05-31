import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { RouterLink } from '@angular/router';
import { RecipeService } from '../services/recipe.service';

@Component({
  selector: 'app-recepies',
  imports: [CommonModule
  ],
  templateUrl: './recepies.component.html',
  styleUrl: './recepies.component.css'
})
export class RecepiesComponent implements OnInit {
  recipes: any[] = [];

  constructor(private recipeService: RecipeService) {

  }
  ngOnInit(): void {
    this.recipeService.getAllRecipes()
      .subscribe(resp => this.recipes = resp)
  }


}
