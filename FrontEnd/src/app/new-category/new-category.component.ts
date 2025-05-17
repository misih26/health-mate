import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-new-category',
  imports: [FormsModule,

  ],
  templateUrl: './new-category.component.html',
  styleUrl: './new-category.component.css'
})
export class NewCategoryComponent {
category: string = "";
saveNewCategory(): void{
  let newRecipes={
    name:this.category,
  }
  let options={
    method:"post",
    body:JSON.stringify(newRecipes),
    headers:{
      "Content-Type":"application/json"
    }
  }
  fetch("https://localhost:7165/Category", options)
  .then(data=>data.json())
  .then(response=>alert("Sikeres mentés"))
}
}

