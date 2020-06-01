import { Injectable } from "@angular/core";

@Injectable({ providedIn: 'root' })
export class AlertService {
  private alerts: Array<string> = new Array()

  public addAlert(alert: string) {
    this.alerts.push(alert);
  }

  get getAlerts() {
    return this.alerts;
  }

  public removeAlert(index: number) {
    this.alerts.splice(index, 1);
  }
}
