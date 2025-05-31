import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Meta } from '@angular/platform-browser';
import { ActivatedRoute } from '@angular/router';
import { CategoryService } from '../services/category.service';

@Component({
  selector: 'app-category-modify',
  imports: [FormsModule],
  templateUrl: './category-modify.component.html',
  styleUrl: './category-modify.component.css'
})
export class CategoryModifyComponent implements OnInit {
  categoryId: string = "";
  category: any;

  constructor(private route: ActivatedRoute, private categoryService: CategoryService) { }

  ngOnInit(): void {

    this.route.paramMap.subscribe(params => this.categoryId = params.get("id") + "")
    this.categoryService.getCategoryById(this.categoryId)
      .subscribe(resp => this.category = resp)
  }

  categoryModify() {
    if (this.category.recipes) {
      delete this.category.recipes
    }
    this.categoryService.modifyCategory(this.category)
      .subscribe(parsed => {
        if (parsed.success) {
          alert("sikeres modify")
        }
      })
  }

}
