import { Component, Input, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AccountService } from '../services/account.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  registerForm! : FormGroup;  
  
  constructor(private accountService: AccountService, private toastr: ToastrService) {   
    
  }

  ngOnInit(): void {
    this.registerForm = new FormGroup({
      'username': new FormControl('', [ Validators.required ]),
      'password': new FormControl('', [ Validators.required ])
    });
  }

  register() {
    console.log("Form Data:" + this.registerForm.value.username, "", this.registerForm.value.password);
    this.accountService.register(this.registerForm.value.username, this.registerForm.value.password)
    .subscribe({
      next: response => {
        console.log("register serivce working" + response);
      },
      error: error => this.toastr.error(error.error)
    })
  }

  reset() {
    this.registerForm.reset();
  }
}
