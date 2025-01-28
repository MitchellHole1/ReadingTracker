import { test, expect } from './helpers';

test.describe('Authors Page Tests', () => {
  test.beforeEach(async ({ page }) => {
    await page.goto('/');
    await page.getByRole('link', { name: 'Authors' }).click();
  });

  test('Should land on the authors page', async ({ page }) => {
    await expect(page).toHaveTitle(/Authors/);
  });

});