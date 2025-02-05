import { Page } from "@playwright/test";

interface IPageObject {
    page: Page;
    url: string;
}

export { IPageObject };