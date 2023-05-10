import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AccountService } from '../services/account.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
 loginForm! : FormGroup;
 model : any = {}
 loggedIn = false;
 constructor(public accService: AccountService) { }  
 
  ngOnInit(): void {
    //this.getCurrentUser(); // no need when using async pipe directly
    this.loginForm = new FormGroup({
      'username': new FormControl('', [ Validators.required ]),
      'password': new FormControl('', [ Validators.required ])
    });
  }

//  getCurrentUser() {
//   this.accService.currentUser$.subscribe({
//     next: user => this.loggedIn = !!user,   //!! turns users into boolean. If user has value it will return true.
//     error: error => console.log(error)
//   })
//  }

 onLogin(){
  debugger;
  console.log("Form Data:" + this.loginForm.value.username , " ",  this.loginForm.value.password)
  this.accService.login(this.loginForm.value.username, this.loginForm.value.password).subscribe({
    next: response => {
      console.log(response);
     // this.loggedIn = true
    },
    error: error => console.log(error)
  });
 }

 logout(){
  this.accService.logout();
 // this.loggedIn = false;
 }

}
