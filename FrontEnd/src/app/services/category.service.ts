import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {
  categoryUrl: string = "https://localhost:7165/Category"
  constructor(private client: HttpClient) { }
  getAllCategory():Observable<any>{
  return this.client.get(this.categoryUrl)
  }
  getCategoryById(id: any):Observable<any>{
    return this.client.get(this.categoryUrl+"/"+id)
  }
  deleteCategory(id: any):Observable<any>{
    return this.client.delete(this.categoryUrl+"/"+id)
  }
  modifyCategory(category: any):Observable<any>{
    return this.client.put(this.categoryUrl, category)
  }
  newCategory(category: any):Observable<any>{
    return this.client.post(this.categoryUrl, category)
  }

}
