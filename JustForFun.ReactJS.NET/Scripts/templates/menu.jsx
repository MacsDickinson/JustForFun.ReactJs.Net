var Menu = React.createClass({
    getDefaultProps: function () {
        return {
            menuItems: [
              { title: 'Home', url: '/' },
              { title: 'Recipes', url: '/recipes' },
              { title: 'Sign In', url: '/account/sign-in', right: true }
            ],
            activeMenuItem: 'Home'
        };
    },
    getInitialState: function () {
        return {
            activeMenuItem: this.props.activeMenuItem
        };
    },
    render: function () {
        var menuItems = this.props.menuItems.map(function (menuItem) {
            return (
              React.createElement(MenuItem, {
                  active: (this.state.activeMenuItem === menuItem.title),
                  key: menuItem.title,
                  title: menuItem.title,
                  url: menuItem.url,
                  right: menuItem.right
              })
            );
        }.bind(this));
        return (
          React.DOM.div({ className: 'ui secondary pointing menu green' }, menuItems)
        );
    }
});

var MenuItem = React.createClass({
    render: function () {
        var className = this.props.active ? 'item active' : 'item';

        if (this.props.right) {
            return React.DOM.div({ className: 'right menu' },
                (<a href={this.props.url} className={className}>{this.props.title}</a>)
            )
        }
        else {
            return (<a href={this.props.url} className={className}>{this.props.title}</a>)
        }
    }
});