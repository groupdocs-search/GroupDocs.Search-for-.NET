import { getGreeting } from '../support/app.po';
describe('search', () => {
    beforeEach(() => cy.visit('/'));
    it('should display welcome message', () => {
        getGreeting().contains('Welcome to search!');
    });
});
//# sourceMappingURL=app.spec.js.map