import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CategoryService } from '../services/category.service';

@Component({
  selector: 'app-new-category',
  imports: [FormsModule,
  ],
  templateUrl: './new-category.component.html',
  styleUrl: './new-category.component.css'
})
export class NewCategoryComponent {
  category: string = "";
  constructor(private categoryService: CategoryService) {

  }

  saveNewCategory(): void {
    let newCategory = {
      name: this.category,
    }
    this.categoryService.newCategory(newCategory)
      .subscribe(resp => newCategory = resp)

  }
}

