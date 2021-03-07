import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-alert',
  templateUrl: './alert.component.html',
  styleUrls: ['./alert.component.css'],
})
export class AlertComponent implements OnInit {
  showAlert: boolean = false;
  alertMessage: string = '';

  constructor() {}

  ngOnInit(): void {}

  onClose() {
    this.showAlert = false;
    this.alertMessage = '';
  }

  setAlert(message: string) {
    this.showAlert = true;
    this.alertMessage = message;
  }
}
