import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../assets/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {
  constructor(private client: HttpClient) { }

  private get categoryUrl(): string {
    return `${environment.apiUrl}/Category`;
  }

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
