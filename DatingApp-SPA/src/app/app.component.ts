//#region Importation
import { Component, OnInit } from '@angular/core';
import { AuthService } from './_services/auth.service';
import { JwtHelperService } from '@auth0/angular-jwt';
//#endregion

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

//#region  Class
export class AppComponent implements OnInit {
  
  title = 'app';
  jstHelper = new JwtHelperService();
  
  constructor(private authService: AuthService) { }

  ngOnInit() {
    const token = localStorage.getItem('token');
    if (token) {
      this.authService.decodedToken = this.jstHelper.decodeToken(token);
    }
  }

}
//#endregion
