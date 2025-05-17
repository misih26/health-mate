import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormsModule } from '@angular/forms';

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

  ngOnInit(): void {
    fetch("https://localhost:7165/Category")
      .then(response => response.json())
      .then(parsedResponse => this.categories = parsedResponse)
  }
  saveNewRecipes(): void{
    let newRecipes={
      name:this.title,
      description:this.description,
      categoryId:this.category
    }
    let options={
      method:"post",
      body:JSON.stringify(newRecipes),
      headers:{
        "Content-Type":"application/json"
      }
    }
    fetch("https://localhost:7165/Recipe", options)
    .then(data=>data.json())
    .then(response=>alert("Sikeres mentés"))
  }
}
