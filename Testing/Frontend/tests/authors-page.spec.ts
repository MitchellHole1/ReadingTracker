import { test, expect } from './helpers';
const { AuthorsPage } = require('../page_objects/authors-page')

test.describe('Authors Page Tests', () => {

  let authorsPage;

  test.beforeEach(async ({ page }) => {
    authorsPage = new AuthorsPage(page);
    await page.goto('/');
    await page.getByRole('link', { name: 'Authors' }).click();
  });

  test('Should land on the authors page', async ({ page }) => {
    await expect(page).toHaveTitle(/Authors/);
    await expect(page.url()).toContain(authorsPage.url);
    await expect(page.locator('text=Add Author')).toBeVisible();
  });

  test('Should Display Authors Table', async ({ page }) => {
    authorsPage.table_headers.forEach(async (header) => {
      await expect(page.getByText(header, { exact: true })).toBeVisible();
    });
    await expect(page.getByRole('cell', { name: 'Adrian Tchaikovsky' })).toBeVisible();
  });

});