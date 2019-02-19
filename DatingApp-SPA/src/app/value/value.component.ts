//#region Importations
import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
//#endregion

@Component({
  selector: 'app-value',
  templateUrl: './value.component.html',
  styleUrls: ['./value.component.css']
})

//#region Class
export class ValueComponent implements OnInit {

  // Attributes.
  values: any;

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getValues();
  }

  getValues() {
    this.http.get('http://localhost:5000/api/values')
      .subscribe(
        response => {
          // Get response.
          this.values = response;
        },
        error => {
          // Show error.
          console.error(error);
        }
      );
  }

}
//#endregion
