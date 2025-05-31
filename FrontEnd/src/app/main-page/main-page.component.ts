import { Component } from '@angular/core';

@Component({
  selector: 'app-main-page',
  imports: [],
  templateUrl: './main-page.component.html',
  styleUrl: './main-page.component.css'
})
export class MainPageComponent {
  appDescription = `
    A HealthMate egy egészségtudatos receptkezelő alkalmazás, ahol recepteket és kategóriákat hozhatsz létre, módosíthatsz vagy törölhetsz.
    Kategóriánként szűrve is válogathatsz számos egészséges recept közül , és egy diagram segítségével láthatod, hogy melyik kategóriában hány recept található meg.
  `;
}
