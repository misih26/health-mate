import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ConfigService } from './config.service';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {
  constructor(private client: HttpClient, private configService: ConfigService) { }

  private get categoryUrl(): string {
    return `${this.configService.cfg.apiUrl}/Category`;
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
