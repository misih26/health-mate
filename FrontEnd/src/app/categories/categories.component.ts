import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-categories',
  imports: [CommonModule],
  templateUrl: './categories.component.html',
  styleUrl: './categories.component.css'
})
export class CategoriesComponent implements OnInit {
  categories: any[] = [];
  show(): void{
    fetch("https://localhost:7165/Category")
      .then(response => response.json())
      .then(parsedResponse => this.categories = parsedResponse)
  }
  ngOnInit(): void {
    this.show();
  }
  delete(id: string): void {
    const options = {
      method: "DELETE"
    }
    fetch("https://localhost:7165/Category/"+id, options)
    .then(Response=>Response.json())
    .then(parsedResponse=>{
      if(parsedResponse.success){
          alert("Törölve")
          this.show();
      }
      else{
        alert("Sikertelen törlés")
      }
    })
  }
}
