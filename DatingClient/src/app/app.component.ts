import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'Dating App';
  users! : any
  
  constructor(private http: HttpClient) { }    
  
  ngOnInit(): void {
      this.http.get('http://localhost:5286/api/Users/').subscribe(resp => {
        if(resp != null)
        {    
          this.users = resp;      
        }
        console.log("User:" + this.users);
      },
      error => console.log(error)
      );      
  }
}
