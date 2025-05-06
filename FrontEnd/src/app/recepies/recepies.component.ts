import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-recepies',
  imports: [CommonModule],
  templateUrl: './recepies.component.html',
  styleUrl: './recepies.component.css'
})
export class RecepiesComponent implements OnInit {
  recipes:any[]=[];
  ngOnInit(): void {
 fetch("https://localhost:7165/Recipe")
 .then(response=>response.json())
 .then(response=>this.recipes=response);
}


}
