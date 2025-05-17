import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class RecipeService {

  private url="https://localhost:7165/Category"
  constructor(private client: HttpClient) { }

  getRecipesByCategory(id: string):Observable<any>{
    return this.client.get(this.url+"/"+id)
  }
}
