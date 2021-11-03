import { createOfflineCompileUrlResolver } from '@angular/compiler';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { User } from './user';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})



export class AppComponent {
  title = 'Instantgram'

  public navbar = [
    {link: '/home', title: 'Home'},
    {link: '/explore', title: 'Explore'}
  ];

  public user?: User//sessionStorage.getItem('user')
  public router: Router

  constructor(router: Router) {
    this.router = router
    const username = sessionStorage.getItem('username')
    if (username) {
      this.user = new User()
      this.user.userName = username
      this.user.Id = sessionStorage.getItem('userID') || ''
    }
  }

  logout() {
    sessionStorage.clear()
  }

}
