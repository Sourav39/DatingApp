import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { User } from './_model/user';
import { AccountService } from './services/account.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'Dating App';
  users! : any
  
  constructor(private http: HttpClient, private accountService: AccountService) { }    
  
  ngOnInit(): void {
        this.getUsers();
        this.setCurrentUser();
  }

  getUsers() {
    this.http.get('http://localhost:5001/api/users').subscribe({
      next: response => this.users = response,
      error: error => console.log(error),
      complete: () => console.log("Request has complete")
    });    
  }

  setCurrentUser() {   //will set user to BS when browser is closed accidently and relaunched again.
    const userString = localStorage.getItem('user');
    if(!userString) return;
    const user: User = JSON.parse(userString);
    this.accountService.setCurrentUser(user);
  }
}
