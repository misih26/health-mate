import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Meta } from '@angular/platform-browser';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-category-modify',
  imports: [FormsModule],
  templateUrl: './category-modify.component.html',
  styleUrl: './category-modify.component.css'
})
export class CategoryModifyComponent implements OnInit {
  categoryId: string ="";
  category: any;

  constructor(private route: ActivatedRoute) {}

  ngOnInit(): void {
    this.route.paramMap.subscribe(params=>this.categoryId=params.get("id")+"")
    fetch("https://localhost:7165/Category/"+this.categoryId)
    .then(response=>response.json())
    .then(parsed=>this.category=parsed)
  }
  categoryModify(){
    if(this.category.recipes){
      delete this.category.recipes
    }
    const options = {
      method: "PUT",
      body: JSON.stringify(this.category),
      headers: {
        "Content-Type": "application/json"
      }
    }
    fetch("https://localhost:7165/Category", options)
    .then(response=> response.json())
    .then(parsed=>{
      if(parsed.success){
          alert("sikeres modify")
      }
    })
    console.log(this.category);
  }

}
