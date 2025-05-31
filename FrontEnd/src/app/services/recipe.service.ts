import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class RecipeService {

  private url="https://localhost:7165/Category"
  private recipeUrl="https://localhost:7165/Recipe"
  constructor(private client: HttpClient) { }

  getRecipesByCategory(name: string):Observable<any>{
    return this.client.get(this.url+"/ByName/"+name)
  }
  getAllRecipes():Observable<any>{
    return this.client.get(this.recipeUrl)
  }
  saveNewRecipe(newRecipe: any){
    return this.client.post(this.recipeUrl, newRecipe)
  }
}
