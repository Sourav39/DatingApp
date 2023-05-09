import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
 baseUrl = 'http://localhost:5001/api/';

 loginDTO : any = {};

  constructor(private http: HttpClient) { }

  login(username: string, password: string){
    this.loginDTO = {
      'username' : username,
      'password' : password
    }
    return this.http.post(this.baseUrl + 'account/login', this.loginDTO);
  }

}
