import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { RouterLink } from '@angular/router';
import { CategoryService } from '../services/category.service';

@Component({
  selector: 'app-categories',
  imports: [CommonModule,
  ],
  templateUrl: './categories.component.html',
  styleUrl: './categories.component.css'
})
export class CategoriesComponent implements OnInit {
  categories: any[] = [];
  constructor(private categoryService: CategoryService) {

  }
  show(): void {
    this.categoryService.getAllCategory()
      .subscribe(resp => this.categories = resp)
  }
  ngOnInit(): void {
    this.show();
  }
  delete(id: string): void {
    this.categoryService.deleteCategory(id)
      .subscribe(resp => {
        if (resp.success) {
          alert("Törölve")
          this.show();
        }
        else {
          alert("Sikertelen törlés")
        }
      })
  }
}
