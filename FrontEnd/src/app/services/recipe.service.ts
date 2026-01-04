import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../assets/environments/environment';




@Injectable({
  providedIn: 'root'
})
export class RecipeService {

  constructor(private client: HttpClient) { }

  // 3. Dinamikus URL-ek létrehozása
 private get categoryUrl(): string {
    return `${environment.apiUrl}/Category`;
  }

  private get recipeUrl(): string {
    return `${environment.apiUrl}/Recipe`;
  }
  getRecipesByCategory(name: string):Observable<any>{
    return this.client.get(`${this.categoryUrl}/ByName/${name}`)
  }
  getAllRecipes():Observable<any>{
    return this.client.get(this.recipeUrl)
  }
  saveNewRecipe(newRecipe: any){
    return this.client.post(this.recipeUrl, newRecipe)
  }
}
