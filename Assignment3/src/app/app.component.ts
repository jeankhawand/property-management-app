import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'Assignment3';
  links = [
    { path: '/', icon: 'home', title: 'Home' },
    { path: '/apartments', icon: 'view_list', title: 'Apartments' },
  ];

}
