import { Component, OnInit } from '@angular/core';
import { StarwarService } from 'src/services/starwar.service';
import { Character } from './character';

//import characters from './_files/StarWars.json'

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  public items: Character[]=[];

  /**
   *
   */
  constructor(public service:StarwarService) {
  
    
  }
  ngOnInit(): void {
 
    var result = this.service.getCharacters().subscribe(data =>
      {
        this.items = data;
      })
  }
    

  
  title = 'jedi-test';

 
  
}


