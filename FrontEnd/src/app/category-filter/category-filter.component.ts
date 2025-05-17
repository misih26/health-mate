import { Component, OnInit } from '@angular/core';
import { RecipeService } from '../services/recipe.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-category-filter',
  imports: [],
  templateUrl: './category-filter.component.html',
  styleUrl: './category-filter.component.css'
})
export class CategoryFilterComponent implements OnInit {
  categoryId: string="";
  category: any []=[];
  constructor(private recipeService: RecipeService, private route: ActivatedRoute){}
  ngOnInit(): void {
    this.route.paramMap.subscribe(params=>this.categoryId=params.get("id")+"")
    fetch("https://localhost:7165/Category/"+this.categoryId)
    .then(response=>response.json())
    .then(parsed=>this.category=parsed)
  }

}

