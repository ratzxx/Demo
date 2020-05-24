import { Component } from '@angular/core';
import { IUser } from '../shared/models/user.model';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {

  Users: IUser[];

  
}
