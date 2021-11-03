import { Component, OnInit } from '@angular/core'
import { HttpClient } from '@angular/common/http'
import { HtmlParser } from '@angular/compiler'
import { LoginResponse } from '../login-response'
import { Router } from '@angular/router'
import { Login } from '../login'

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  public http: HttpClient
  public router: Router
  constructor(http: HttpClient, router: Router) {
    this.http = http
    this.router = router
  }

  login(name: HTMLInputElement, pass: HTMLInputElement) {
    if (!name.value && !pass.value) {
      window.alert('You need to fill the inputfields!')
      return;
    }
    if (sessionStorage.getItem('token')) {
      console.log('You are already logged in!!')
      return;
    }
    console.log('[user: ', name.value, ', password: ', pass.value, '] receved.')
    const loginUser = new Login(name.value, pass.value)
    const username = name.value

    this.http.post<LoginResponse>('https://localhost:7766/auth/login', loginUser).subscribe(response => {
      console.log(response)
      const token = response.token
      const userID = response.userId
      if (token != null && token.toString().length > 3) {
        sessionStorage.setItem('token', token)
        sessionStorage.setItem('username', username)
        sessionStorage.setItem('userID', userID)
        this.router.navigate(['/home'])
      }
    }, error => {
      if (error.status.toString() === '401')
        window.alert('Invalid username or password!!')
      else
        console.log(error)
    })
  }

  logout() {
    sessionStorage.clear()
  }

  ngOnInit(): void {
  }

}
