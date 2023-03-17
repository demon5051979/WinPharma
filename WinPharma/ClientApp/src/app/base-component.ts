export class BaseComponent {
    constructor() {}

    public isLoading = false;
    public error: string;

    public showError(error: any) {
        this.isLoading = false;
        console.error(error);
        this.error = "Service unavailable, please try later.";
    }
}
