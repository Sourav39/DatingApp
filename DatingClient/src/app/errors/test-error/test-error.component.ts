import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-test-error',
  templateUrl: './test-error.component.html',
  styleUrls: ['./test-error.component.css']
})
export class TestErrorComponent implements OnInit {

  baseUrl = 'http://localhost:5001/api/';
  validationError: string[] =[];

  constructor(private http: HttpClient) 
  {

  }
  ngOnInit(): void {
  }

  get404Error()
  {
    this.http.get(this.baseUrl + 'buggy/not-found').subscribe({
      next: response => console.log(response),
      error: error => console.log('error 404 testing' + error)
    })
  }

  get400Error()
  {
    this.http.get(this.baseUrl + 'buggy/bad-request').subscribe({
      next: response => console.log(response),
      error: error => console.log('error 400 testing' + error)
    })
  }

  get500Error()
  {
    this.http.get(this.baseUrl + 'buggy/server-error').subscribe({
      next: response => console.log(response),
      error: error => console.log('error 500 testing' + error)
    })
  }

  get401Error()
  {
    this.http.get(this.baseUrl + 'buggy/auth').subscribe({
      next: response => console.log(response),
      error: error => console.log('error 401 testing' + error)
    })
  }

  get400Validation()
  {
    this.http.post(this.baseUrl + 'account/register', {}).subscribe({
      next: response => console.log(response),
      error: error => {
        console.log('error 400 Validation testing' + error),
        this.validationError = error;
      }
    })
  }
}
