import { Component } from '@angular/core';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {

  timeNow: string = ""

  constructor() { }

  public async ngOnInit() {

    setInterval(() => this.getTime(), 1000);

  }

  public async getTime() {

    const now = new Date();

    let min, sec = "";
    if (now.getMinutes()<10) {min = "0"+ now.getMinutes();}
    if (now.getMinutes()>10) {min = now.getMinutes();}
    if (now.getSeconds()<10) {sec = "0"+ now.getSeconds();}
    if (now.getSeconds()>10) {sec = now.getSeconds().toString();}
    
    this.timeNow = now.getHours() + ":" + min + ":" + sec;
  }

}
