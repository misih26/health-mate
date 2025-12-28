import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ConfigService } from './config.service';



@Injectable({
  providedIn: 'root'
})
export class RecipeService {


  //private recipeUrl = `${environment.apiUrl}/Recipe`;
  constructor(private client: HttpClient, private configService: ConfigService) { }

  // 3. Dinamikus URL-ek létrehozása
  private get categoryUrl(): string {
    return `${this.configService.cfg.apiUrl}/Category`;
  }

  private get recipeUrl(): string {
    return `${this.configService.cfg.apiUrl}/Recipe`;
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
