import { test, expect } from './helpers';

const { BooksPage } = require('../page_objects/books-page')

test.describe('Books Page Tests', () => {

  let booksPage;


  test.beforeEach(async ({ page }) => {
    booksPage = new BooksPage(page);

    await page.goto('/');
    await page.getByRole('link', { name: 'Books' }).click();
  });

  test('Should land on the books page', async ({ page }) => {
    await expect(page).toHaveTitle(/Books/);
  });

  test('Should display a list of books', async ({ page }) => {
    booksPage.table_headers.forEach(async (header) => {
      await expect(page.getByText(header, { exact: true })).toBeVisible();
    });
    await expect(page.locator('text=The Hobbit')).toBeVisible();
    await expect(page.locator('text=The Road')).toBeVisible();
  });

});