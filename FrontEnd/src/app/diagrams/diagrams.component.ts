import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-diagrams',
  imports: [CommonModule],
  templateUrl: './diagrams.component.html',
  styleUrl: './diagrams.component.css'
})
export class DiagramsComponent implements OnInit {
  categories: any[] = [];
  sum: number = 0;
  columnColors: string[] = [];
  randomColor(): string {
    let randomegy: Number = Math.floor(Math.random() * 155) + 100
    let randomketto: Number = Math.floor(Math.random() * 155) + 100
    let randomharom: Number = Math.floor(Math.random() * 155) + 100
    let x: string = `rgb(${randomegy},${randomketto},${randomharom})`
    this.columnColors.push(x);
    return x;
  }
  columnHeight(list: number): number {
    console.log(list);
    return Math.ceil(list / this.sum * 100);
  }
  ngOnInit(): void {
    fetch("https://localhost:7165/Category")
      .then(response => response.json())
      .then(parsed => {
        this.categories = parsed;
        for (let item of this.categories) {
          this.sum += item.recipes.length
        }
      });
  }

}
